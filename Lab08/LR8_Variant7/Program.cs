using System;
using System.Text;

namespace LR8_Variant7
{
    // Тип-перечисление видов топлива
    public enum FuelType
    {
        Бензин,
        Дизель,
        АвиационныйКеросин,
        Электричество
    }

    // Базовый класс иерархии
    public class Машины
    {
        protected string model;
        protected int year;
        protected int powerHp;
        protected FuelType fuel;

        public Машины(string model, int year, int powerHp, FuelType fuel)
        {
            this.model = model;
            this.year = year;
            this.powerHp = powerHp;
            this.fuel = fuel;
        }

        // Переопределяемое свойство
        public virtual string Category
        {
            get { return "Общее механическое транспортное средство"; }
        }

        // Переопределяемый метод
        public virtual void Info()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Категория:    {0}", Category);
            Console.WriteLine("Модель:       {0}", model);
            Console.WriteLine("Год выпуска:  {0}", year);
            Console.WriteLine("Мощность:     {0} л.с.", powerHp);
            Console.WriteLine("Тип топлива:  {0}", fuel);
        }
    }

    // Производный класс 1 уровня: Грузовик
    public class Грузовик : Машины
    {
        private double loadCapacityTons;

        public Грузовик(string model, int year, int powerHp, FuelType fuel, double loadCapacityTons)
            : base(model, year, powerHp, fuel)
        {
            this.loadCapacityTons = loadCapacityTons;
        }

        public override string Category
        {
            get { return "Грузовой наземный автотранспорт"; }
        }

        public override void Info()
        {
            // Вызов базового метода
            base.Info();
            Console.WriteLine("Грузоподъемность: {0} тонн", loadCapacityTons);
        }
    }

    // Производный класс 1 уровня: Авиасредство
    public class Авиасредство : Машины
    {
        protected double maxAltitudeM;

        public Авиасредство(string model, int year, int powerHp, FuelType fuel, double maxAltitudeM)
            : base(model, year, powerHp, fuel)
        {
            this.maxAltitudeM = maxAltitudeM;
        }

        public override string Category
        {
            get { return "Авиационное транспортное средство"; }
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Макс. высота: {0} м", maxAltitudeM);
        }
    }

    // Производный класс 2 уровня: Вертолет
    public class Вертолет : Авиасредство
    {
        private int bladesCount;

        public Вертолет(string model, int year, int powerHp, FuelType fuel, double maxAltitudeM, int bladesCount)
            : base(model, year, powerHp, fuel, maxAltitudeM)
        {
            this.bladesCount = bladesCount;
        }

        public override string Category
        {
            get { return "Винтокрылый летательный аппарат (Вертолет)"; }
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Количество лопастей: {0}", bladesCount);
        }
    }

    // Производный класс 2 уровня: Истребитель
    public class Истребитель : Авиасредство
    {
        private double machSpeed;

        public Истребитель(string model, int year, int powerHp, FuelType fuel, double maxAltitudeM, double machSpeed)
            : base(model, year, powerHp, fuel, maxAltitudeM)
        {
            this.machSpeed = machSpeed;
        }

        public override string Category
        {
            get { return "Сверхзвуковой военный истребитель"; }
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Макс. скорость: {0} Маха", machSpeed);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("   ЛАБОРАТОРНАЯ РАБОТА №8: ИЕРАРХИЯ КЛАССОВ       ");
            Console.WriteLine("   Вариант 7: Машины -> Авиасредство / Грузовик   ");
            Console.WriteLine("==================================================");

            // Демонстрация полиморфизма через массив базового типа
            Машины[] fleet = new Машины[]
            {
                new Грузовик("КАМАЗ-54901", 2023, 450, FuelType.Дизель, 20.0),
                new Вертолет("Ми-8МТВ", 2021, 2000, FuelType.АвиационныйКеросин, 6000.0, 5),
                new Истребитель("Су-35С", 2024, 29000, FuelType.АвиационныйКеросин, 20000.0, 2.25)
            };

            for (int i = 0; i < fleet.Length; i++)
            {
                Console.WriteLine("\n[Объект #{0}: Тип {1}]", i + 1, fleet[i].GetType().Name);
                fleet[i].Info();
            }

            Console.WriteLine("\n==================================================");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
