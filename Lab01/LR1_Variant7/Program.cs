using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_One_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Часть 1. Вывод персональной информации о студенте
            Console.WriteLine("==========================================================");
            Console.WriteLine("           ЛАБОРАТОРНАЯ РАБОТА №1 (ВАРИАНТ 7)             ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("ФИО студента:           Мухамеджанов Э. Т.");
            Console.WriteLine("Группа:                 ПИН-б-о-24-1");
            Console.WriteLine("Шифр специальности:     09.03.03 Прикладная информатика");
            Console.WriteLine("Дата рождения:          15.03.2005");
            Console.WriteLine("Место жительства:       г. Ставрополь");
            Console.WriteLine("Любимый школьный предм: Информатика");
            Console.WriteLine("Хобби и увлечения:      Программирование на C#, 3D-моделирование, спорт");
            Console.WriteLine("----------------------------------------------------------\n");

            // Часть 2. Вычисление выражения по варианту 7:
            // U = (35 / a) * z + z * a - (a + E * t) / 4
            Console.WriteLine("ВЫЧИСЛЕНИЕ ВЫРАЖЕНИЯ ПО ВАРИАНТУ 7:");
            Console.WriteLine("Формула: U = (35 / a) * z + z * a - (a + E * t) / 4\n");

            double a = 5.0;
            double z = 2.0;
            double E = 10.0;
            double t = 1.5;

            double term1 = (35.0 / a) * z;
            double term2 = z * a;
            double term3 = (a + E * t) / 4.0;
            double U = term1 + term2 - term3;

            Console.WriteLine("Исходные переменные:");
            Console.WriteLine("  a = {0:0.00}", a);
            Console.WriteLine("  z = {0:0.00}", z);
            Console.WriteLine("  E = {0:0.00}", E);
            Console.WriteLine("  t = {0:0.00}", t);
            Console.WriteLine();
            Console.WriteLine("Промежуточные слагаемые:");
            Console.WriteLine("  (35 / a) * z       = {0:0.0000}", term1);
            Console.WriteLine("  z * a              = {0:0.0000}", term2);
            Console.WriteLine("  (a + E * t) / 4    = {0:0.0000}", term3);
            Console.WriteLine();
            Console.WriteLine("Итоговый результат: U = {0:0.0000}", U);
            Console.WriteLine("==========================================================");
            Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
