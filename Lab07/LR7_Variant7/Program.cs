using System;
using System.IO;
using System.Text;

namespace LR7_Variant7
{
    public class Cube
    {
        private double a; // длина ребра куба

        // 1. Конструктор по умолчанию
        public Cube()
        {
            a = 1.0;
        }

        // 2. Параметризованный конструктор
        public Cube(double edge)
        {
            a = edge > 0 ? edge : 1.0;
        }

        // 3. Фабричный метод создания объекта из потока
        public static Cube CreateFromFile()
        {
            double val = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            return new Cube(val);
        }

        // Вычисление объема
        public double GetV()
        {
            return Math.Pow(a, 3);
        }

        // Вычисление площади полной поверхности
        public double GetS()
        {
            return 6.0 * Math.Pow(a, 2);
        }

        // Вычисление длины пространственной диагонали: d = a * sqrt(3)
        public double GetDiagonal()
        {
            return a * Math.Sqrt(3.0);
        }

        // Перегрузка метода 1: Стандартный вывод полной информации
        public void Info()
        {
            string str =
                "**************************************************\n" +
                "*                 ГЕОМЕТРИЯ: КУБ                 *\n" +
                "**************************************************";
            Console.WriteLine(str);
            Console.WriteLine(string.Format("Длина ребра a   = {0:0.00}", a));
            Console.WriteLine(string.Format("Объем V         = {0:0.000}", GetV()));
            Console.WriteLine(string.Format("Площадь пов. S  = {0:0.000}", GetS()));
            Console.WriteLine(string.Format("Диагональ d     = {0:0.000}", GetDiagonal()));
            Console.WriteLine("**************************************************");
        }

        // Перегрузка метода 2: Цветной вывод в консоль
        public void Info(ConsoleColor fg, ConsoleColor bg)
        {
            ConsoleColor prevFg = Console.ForegroundColor;
            ConsoleColor prevBg = Console.BackgroundColor;

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Info();

            Console.ForegroundColor = prevFg;
            Console.BackgroundColor = prevBg;
        }

        // Перегрузка метода 3: Краткий формат вывода
        public void Info(bool shortFormat)
        {
            if (shortFormat)
            {
                Console.WriteLine(string.Format("[Куб: a={0:0.00}, V={1:0.00}, S={2:0.00}, d={3:0.00}]",
                    a, GetV(), GetS(), GetDiagonal()));
            }
            else
            {
                Info();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

#if !DEBUG
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"cube_output.txt");
            var new_in = new StreamReader(@"cube_input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            Cube c1 = Cube.CreateFromFile();
            c1.Info();

            Cube c2 = new Cube(5.5);
            c2.Info(true);

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
#else
            Console.WriteLine("=== [DEBUG СБОРКА] Демонстрация перегрузок конструкторов и методов ===");
            
            // 1. Конструктор по умолчанию
            Cube cDefault = new Cube();
            Console.WriteLine("\n1) Объект по умолчанию:");
            cDefault.Info(true);

            // 2. Параметризованный конструктор с цветным выводом
            Cube cParam = new Cube(4.0);
            Console.WriteLine("\n2) Объект с ребром 4.0 (Цветной вывод):");
            cParam.Info(ConsoleColor.Yellow, ConsoleColor.DarkBlue);

            // 3. Создание второго объекта
            Cube cBig = new Cube(10.0);
            Console.WriteLine("\n3) Большой куб (Краткий формат):");
            cBig.Info(true);

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
#endif
        }
    }
}
