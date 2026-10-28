using System;
using System.IO;

namespace LR4_Demo
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
            string str_all = Console.ReadLine().Trim();
            string[] str_elem = str_all.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int[] mas = new int[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = Convert.ToInt32(str_elem[i]);
            }

            int s = 0;
            float sa = 0;
            for (int i = 0; i < N; i++)
            {
                s += mas[i];
            }
            sa = 1.0f * s / N;

            Console.WriteLine(string.Format("{0:0.000000}", sa));
            for (int i = 0; i < N; i++)
            {
                if (mas[i] >= sa)
                {
                    Console.Write(mas[i] + " ");
                }
            }
            Console.WriteLine();

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
