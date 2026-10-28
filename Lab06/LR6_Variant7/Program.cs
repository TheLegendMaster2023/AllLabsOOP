using System;
using System.IO;
using System.Text;

namespace LR6_Variant7
{
    public class MatrixMxN
    {
        private int m; // количество строк
        private int n; // количество столбцов
        private int[,] data;

        public MatrixMxN()
        {
            m = 0;
            n = 0;
            data = new int[0, 0];
        }

        public MatrixMxN(int rows, int cols)
        {
            m = rows;
            n = cols;
            data = new int[m, n];
        }

        public void InitRandom(int minVal = -50, int maxVal = 50)
        {
            Random rnd = new Random(777);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    data[i, j] = rnd.Next(minVal, maxVal + 1);
                }
            }
        }

        public void Load()
        {
            m = Convert.ToInt32(Console.ReadLine().Trim());
            n = Convert.ToInt32(Console.ReadLine().Trim());
            data = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine().Trim();
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    data[i, j] = Convert.ToInt32(parts[j]);
                }
            }
        }

        public int GetMax()
        {
            int max = data[0, 0];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (data[i, j] > max)
                        max = data[i, j];
            return max;
        }

        public int GetMin()
        {
            int min = data[0, 0];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (data[i, j] < min)
                        min = data[i, j];
            return min;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0,6} ", data[i, j]));
                }
                Console.WriteLine();
            }
        }

        public void Info()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("*             ОБЪЕКТ «МАТРИЦА MxN»               *");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Размерность матрицы: {0} x {1}", m, n);
            Console.WriteLine("Максимальный элемент: {0}", GetMax());
            Console.WriteLine("Минимальный элемент:  {0}", GetMin());
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Элементы матрицы:");
            PrintMatrix();
            Console.WriteLine("**************************************************");
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
            var new_out = new StreamWriter(@"matrix_output.txt");
            var new_in = new StreamReader(@"matrix_input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            MatrixMxN matrix = new MatrixMxN();
            matrix.Load();
            matrix.Info();

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
#else
            Console.WriteLine("=== [DEBUG СБОРКА] Интерактивный режим работы ===");
            MatrixMxN matrix = new MatrixMxN(3, 4);
            matrix.InitRandom(-20, 50);
            matrix.Info();

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
#endif
        }
    }
}
