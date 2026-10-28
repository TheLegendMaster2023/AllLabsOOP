using System;
using System.IO;

namespace LR5_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int N = 4; // строк
            int M = 5; // столбцов
            string fileName = "input.txt";

            if (args.Length >= 2)
            {
                int.TryParse(args[0], out N);
                int.TryParse(args[1], out M);
            }
            else if (!Console.IsInputRedirected)
            {
                Console.Write("Inter N (rows) > ");
                N = Convert.ToInt32(Console.ReadLine());
                Console.Write("Inter M (cols) > ");
                M = Convert.ToInt32(Console.ReadLine());
                Console.Write("Inter file name (without ext) > ");
                fileName = Console.ReadLine() + ".txt";
            }

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(fileName);
            Console.SetOut(new_out);

            Console.WriteLine(N);
            Console.WriteLine(M);

            Random r = new Random(42);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int val = r.Next(-50, 51);
                    Console.Write(val + (j == M - 1 ? "" : " "));
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out);
            new_out.Close();

            Console.WriteLine("File " + fileName + " was created!!!!");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
