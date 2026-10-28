using System;
using System.Text;

namespace LR9_Variant7
{
    // Интерфейс расчета стоимости и применения скидки
    public interface ICalculable
    {
        double CalculateCost();
        void ApplyDiscount(double percent);
    }

    // Интерфейс отображения информации об объекте
    public interface IDisplayable
    {
        string Title { get; set; }
        void Display();
    }

    // Класс 1: Серверное оборудование
    public class ServerEquipment : ICalculable, IDisplayable
    {
        public string Title { get; set; }
        private double basePrice;
        private int cpuSockets;
        private int rackUnits;

        public ServerEquipment(string title, double basePrice, int cpuSockets, int rackUnits)
        {
            Title = title;
            this.basePrice = basePrice;
            this.cpuSockets = cpuSockets;
            this.rackUnits = rackUnits;
        }

        public double CalculateCost()
        {
            // Стоимость с учетом количества сокетов
            return basePrice * (1.0 + (cpuSockets - 1) * 0.35);
        }

        public void ApplyDiscount(double percent)
        {
            basePrice -= basePrice * (percent / 100.0);
        }

        public void Display()
        {
            Console.WriteLine("[Серверное оборудование] " + Title);
            Console.WriteLine("  Форм-фактор:     {0}U", rackUnits);
            Console.WriteLine("  Кол-во сокетов:  {0}", cpuSockets);
            Console.WriteLine("  Итоговая цена:   {0:C2}", CalculateCost());
        }
    }

    // Класс 2: Лицензия на программное обеспечение
    public class SoftwareLicense : ICalculable, IDisplayable
    {
        public string Title { get; set; }
        private double userCost;
        private int usersCount;

        public SoftwareLicense(string title, double userCost, int usersCount)
        {
            Title = title;
            this.userCost = userCost;
            this.usersCount = usersCount;
        }

        public double CalculateCost()
        {
            // Стоимость лицензий на всех пользователей со ступенчатой скидкой на объем
            double total = userCost * usersCount;
            if (usersCount >= 100) total *= 0.85; // 15% скидка от объема
            return total;
        }

        public void ApplyDiscount(double percent)
        {
            userCost -= userCost * (percent / 100.0);
        }

        public void Display()
        {
            Console.WriteLine("[Лицензия на ПО] " + Title);
            Console.WriteLine("  Пользователей:   {0}", usersCount);
            Console.WriteLine("  Цена за раб.место: {0:C2}", userCost);
            Console.WriteLine("  Итоговая цена:   {0:C2}", CalculateCost());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("   ЛАБОРАТОРНАЯ РАБОТА №9: ИНТЕРФЕЙСЫ И ПОЛИМОРФИЗМ");
            Console.WriteLine("   Вариант 7: Интерфейсы ICalculable и IDisplayable");
            Console.WriteLine("==================================================\n");

            // Коллекция объектов разного типа, объединенных интерфейсом IDisplayable
            IDisplayable[] catalog = new IDisplayable[]
            {
                new ServerEquipment("Dell PowerEdge R750", 1250000, 2, 2),
                new SoftwareLicense("PostgreSQL Enterprise", 45000, 120),
                new ServerEquipment("HPE ProLiant DL380", 1400000, 4, 4),
                new SoftwareLicense("1С:Предприятие КОРП", 32000, 50)
            };

            Console.WriteLine("--- 1. Полиморфный вывод каталога через IDisplayable ---");
            foreach (var item in catalog)
            {
                item.Display();
                Console.WriteLine();
            }

            Console.WriteLine("--- 2. Применение скидки 10% через ICalculable ---");
            foreach (var item in catalog)
            {
                ICalculable calc = item as ICalculable;
                if (calc != null)
                {
                    calc.ApplyDiscount(10.0);
                    Console.WriteLine("Скидка применена к {0}: новая стоимость = {1:C2}", item.Title, calc.CalculateCost());
                }
            }

            Console.WriteLine("\n==================================================");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
