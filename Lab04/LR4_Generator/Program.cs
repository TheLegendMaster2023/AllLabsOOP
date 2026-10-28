using System;
using System.IO;

namespace LR4_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int N = 10;
            string fileName = "input.txt";

            if (args.Length >= 1)
            {
                int.TryParse(args[0], out N);
            }
            else if (!Console.IsInputRedirected)
            {
                Console.Write("Inter N > ");
                N = Convert.ToInt32(Console.ReadLine());
                Console.Write("Inter file name (without ext) > ");
                fileName = Console.ReadLine() + ".txt";
            }

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(fileName);
            Console.SetOut(new_out);

            Console.WriteLine(N);

            Random r = new Random(12345);
            for (int i = 0; i < N; i++)
            {
                // Генерируем числа в диапазоне от -100 до 100 для наглядности
                int x = r.Next(-100, 101);
                Console.Write(x + " ");
            }
            Console.WriteLine();

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
