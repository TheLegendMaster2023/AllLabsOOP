using System;
using System.IO;

namespace LR5_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int N = Convert.ToInt32(Console.ReadLine().Trim()); // строки
            int M = Convert.ToInt32(Console.ReadLine().Trim()); // столбцы

            int[,] matrix = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine().Trim();
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = Convert.ToInt32(parts[j]);
                }
            }

            // 1) Вывод исходной матрицы
            Console.WriteLine("*** Исходная матрица ***");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(string.Format("{0,6} ", matrix[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // 2) Вывод суммы элементов по каждой строке
            Console.WriteLine("*** Сумма элементов по строкам ***");
            for (int i = 0; i < N; i++)
            {
                long rowSum = 0;
                for (int j = 0; j < M; j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine(string.Format("Строка {0}: {1}", i + 1, rowSum));
            }
            Console.WriteLine();

            // 3) Среднее арифметическое элементов по каждому столбцу
            Console.WriteLine("*** Среднее арифметическое по столбцам ***");
            for (int j = 0; j < M; j++)
            {
                double colSum = 0;
                for (int i = 0; i < N; i++)
                {
                    colSum += matrix[i, j];
                }
                double colAvg = colSum / N;
                Console.WriteLine(string.Format("Столбец {0}: {1:0.000}", j + 1, colAvg));
            }

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
