using System;
using System.IO;

namespace LR5_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int N = Convert.ToInt32(Console.ReadLine().Trim());
            int M = Convert.ToInt32(Console.ReadLine().Trim());

            int[,] mas = new int[N, M];
            Console.WriteLine("*** Input matrix ***");
            for (int i = 0; i < N; i++)
            {
                string str_all = Console.ReadLine().Trim();
                string[] str_elem = str_all.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("*** Max row elements ***");
            float sa = 0;
            for (int i = 0; i < N; i++)
            {
                int max = -1001;
                for (int j = 0; j < M; j++)
                {
                    if (mas[i, j] > max)
                        max = mas[i, j];
                    sa += mas[i, j];
                }
                Console.WriteLine(max);
            }

            sa = sa / (M * N);
            Console.WriteLine("*** Modifed matrix ***");
            Console.WriteLine(string.Format("Avg = {0:0.000}", sa));
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (mas[i, j] > sa)
                        Console.Write("+ ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
