using System;
using System.IO;
using System.Text;

namespace MatrixLib
{
    public class FileMatrix
    {
        private int rows;
        private int cols;
        private double[,] data;

        public int Rows { get { return rows; } }
        public int Cols { get { return cols; } }

        public FileMatrix()
        {
            rows = 0;
            cols = 0;
            data = new double[0, 0];
        }

        public FileMatrix(int r, int c)
        {
            rows = r;
            cols = c;
            data = new double[rows, cols];
        }

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        // Загрузка матрицы из текстового файла
        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл матрицы не найден: " + path);
            }

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                rows = Convert.ToInt32(reader.ReadLine().Trim());
                cols = Convert.ToInt32(reader.ReadLine().Trim());
                data = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    string line = reader.ReadLine().Trim();
                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < cols; j++)
                    {
                        data[i, j] = Convert.ToDouble(parts[j].Replace('.', ','));
                    }
                }
            }
        }

        // Сохранение матрицы в файл
        public void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine(rows);
                writer.WriteLine(cols);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(string.Format("{0:0.00} ", data[i, j]));
                    }
                    writer.WriteLine();
                }
            }
        }

        // Сумма элементов главной диагонали
        public double GetMainDiagonalSum()
        {
            int n = Math.Min(rows, cols);
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += data[i, i];
            }
            return sum;
        }

        // Сумма элементов второстепенной диагонали
        public double GetSecondaryDiagonalSum()
        {
            int n = Math.Min(rows, cols);
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += data[i, cols - 1 - i];
            }
            return sum;
        }

        // Вывод матрицы в консоль
        public void Print(string caption = "")
        {
            if (!string.IsNullOrEmpty(caption))
            {
                Console.WriteLine("=== " + caption + " ===");
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0,7:0.00} ", data[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
