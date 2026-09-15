using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_One
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Лабораторная работа №1");
            Console.WriteLine("");
            Console.WriteLine("Выполнил: Мухамеджанов Э. Т.");
            Console.WriteLine("Группа: ПИН-б-о-24-1");
            Console.WriteLine("Наименование ЛР: Структура консольного приложения");
            Console.WriteLine("");
            Console.WriteLine("Для завершения работы программы нажмите любую клавишу...");

            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
