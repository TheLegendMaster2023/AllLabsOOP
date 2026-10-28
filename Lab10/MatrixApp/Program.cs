using System;
using System.IO;
using System.Text;
using MatrixLib;

namespace MatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==========================================================");
            Console.WriteLine("    ЛАБОРАТОРНАЯ РАБОТА №10: МНОГОМОДУЛЬНОЕ ПРИЛОЖЕНИЕ    ");
            Console.WriteLine("    Вариант 7: Главная диагональ M1 и побочная M2        ");
            Console.WriteLine("==========================================================\n");

            string file1 = "matrix1.txt";
            string file2 = "matrix2.txt";

            try
            {
                FileMatrix m1 = new FileMatrix();
                m1.LoadFromFile(file1);
                m1.Print("Первая матрица (" + file1 + ")");
                Console.WriteLine();

                FileMatrix m2 = new FileMatrix();
                m2.LoadFromFile(file2);
                m2.Print("Вторая матрица (" + file2 + ")");
                Console.WriteLine();

                double sumMainDiagM1 = m1.GetMainDiagonalSum();
                double sumSecDiagM2 = m2.GetSecondaryDiagonalSum();

                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Результаты расчетов:");
                Console.WriteLine("  Сумма главной диагонали 1-й матрицы:       {0:0.00}", sumMainDiagM1);
                Console.WriteLine("  Сумма второстепенной диагонали 2-й матрицы: {0:0.00}", sumSecDiagM2);
                Console.WriteLine("==========================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке файлов матриц: " + ex.Message);
            }

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
