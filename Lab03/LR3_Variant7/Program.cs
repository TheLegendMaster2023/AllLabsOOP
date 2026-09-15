using System;
using System.IO;

namespace LR_Three_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сохранение исходных потоков ввода-вывода
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int t = 0, N = 1;
            double X = 0, Y = 0, s = 0;

            t = Convert.ToInt32(Console.ReadLine().Trim());
            N = Convert.ToInt32(Console.ReadLine().Trim());
            X = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            Y = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));

            // Вычисление ряда:
            // s = - (Y * X^2)/(1*3) + (X * Y^3)/(2*4) - (Y * X^4)/(3*5) + (X * Y^5)/(4*6) - ...
            // Общий член: для нечетного i: - (Y * X^(i+1)) / (i * (i+2))
            //             для четного i:   + (X * Y^(i+1)) / (i * (i+2))

            if (t == 0)
            {
                // Реализация с использованием цикла for
                for (int i = 1; i <= N; i++)
                {
                    double znam = (double)i * (i + 2);
                    double term;
                    if (i % 2 != 0)
                    {
                        double chisl = Y * Math.Pow(X, i + 1);
                        term = -chisl / znam;
                    }
                    else
                    {
                        double chisl = X * Math.Pow(Y, i + 1);
                        term = chisl / znam;
                    }
                    s += term;
                }
            }
            else if (t == 1)
            {
                // Реализация с использованием цикла while
                int i = 1;
                while (i <= N)
                {
                    double znam = (double)i * (i + 2);
                    double term;
                    if (i % 2 != 0)
                    {
                        double chisl = Y * Math.Pow(X, i + 1);
                        term = -chisl / znam;
                    }
                    else
                    {
                        double chisl = X * Math.Pow(Y, i + 1);
                        term = chisl / znam;
                    }
                    s += term;
                    i++;
                }
            }
            else if (t == 2)
            {
                // Реализация с использованием цикла do ... while
                int i = 1;
                if (N >= 1)
                {
                    do
                    {
                        double znam = (double)i * (i + 2);
                        double term;
                        if (i % 2 != 0)
                        {
                            double chisl = Y * Math.Pow(X, i + 1);
                            term = -chisl / znam;
                        }
                        else
                        {
                            double chisl = X * Math.Pow(Y, i + 1);
                            term = chisl / znam;
                        }
                        s += term;
                        i++;
                    } while (i <= N);
                }
            }

            Console.WriteLine(string.Format("{0:0.0000000}", s));

            // Восстановление потоков и закрытие файлов
            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
