using System;
using System.IO;

namespace LR_Two_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сохраняем исходные потоки ввода-вывода
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            // Связываем стандартные потоки с файлами
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            double a1, a2, a3, a4, a5;
            double s, k;

            // Считывание входных данных из файла input.txt
            a1 = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            a2 = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            a3 = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            a4 = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            a5 = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));

            // Вычисление выражения s:
            // s = sqrt(a2 - a1) / sqrt(a3 - a5) + sqrt(a1) / (a3 - a1)
            // ОДЗ: a2 - a1 >= 0, a3 - a5 > 0, a1 >= 0, a3 - a1 != 0
            if ((a2 - a1 < 0) || (a3 - a5 <= 0) || (a1 < 0) || (a3 - a1 == 0))
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                s = (Math.Sqrt(a2 - a1) / Math.Sqrt(a3 - a5)) + (Math.Sqrt(a1) / (a3 - a1));
                Console.WriteLine(string.Format("{0:0.0000}", s));
            }

            // Вычисление выражения k:
            // k = sqrt(10000 / (a2 - a3)) * (1 / (a2 - a4)^2)
            // ОДЗ: a2 - a3 > 0, a2 - a4 != 0
            if ((a2 - a3 <= 0) || (a2 - a4 == 0))
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                k = Math.Sqrt(10000.0 / (a2 - a3)) * (1.0 / Math.Pow(a2 - a4, 2));
                Console.WriteLine(string.Format("{0:0.0000}", k));
            }

            // Восстановление потоков и закрытие файлов
            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
