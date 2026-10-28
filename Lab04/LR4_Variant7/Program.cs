using System;
using System.IO;

namespace LR4_Variant7
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

            // Чтение данных из файла
            int N = Convert.ToInt32(Console.ReadLine().Trim());
            string line = Console.ReadLine().Trim();
            string[] str_elem = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int[] mas = new int[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = Convert.ToInt32(str_elem[i]);
            }

            // 1) Поиск максимального четного элемента
            bool foundEven = false;
            int maxEven = int.MinValue;

            // 2) Поиск минимального нечетного элемента
            bool foundOdd = false;
            int minOdd = int.MaxValue;

            // 3) Сумма элементов, которые делятся на 5
            long sumDiv5 = 0;

            for (int i = 0; i < N; i++)
            {
                int val = mas[i];

                // Проверка на четность
                if (val % 2 == 0)
                {
                    if (!foundEven || val > maxEven)
                    {
                        maxEven = val;
                        foundEven = true;
                    }
                }
                else
                {
                    // Нечетный элемент
                    if (!foundOdd || val < minOdd)
                    {
                        minOdd = val;
                        foundOdd = true;
                    }
                }

                // Делимость на 5
                if (val % 5 == 0)
                {
                    sumDiv5 += val;
                }
            }

            // Запись результатов в выходной файл
            Console.WriteLine(foundEven ? maxEven.ToString() : "No");
            Console.WriteLine(foundOdd ? minOdd.ToString() : "No");
            Console.WriteLine(sumDiv5.ToString());

            // Восстановление потоков и освобождение ресурсов
            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}
