using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LR11_Variant7
{
    public class Employee
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public string HasPet { get; set; }
        public bool HasWeapon { get; set; }
        public string Login { get; set; }

        public static Employee Create(string csvLine)
        {
            string[] p = csvLine.Split(',');
            return new Employee
            {
                Id = Convert.ToInt32(p[0].Trim()),
                FName = p[1].Trim(),
                LName = p[2].Trim(),
                Department = p[3].Trim(),
                Salary = Convert.ToDouble(p[4].Trim().Replace('.', ',')),
                HasPet = p[5].Trim(),
                HasWeapon = Convert.ToBoolean(p[6].Trim()),
                Login = p.Length > 7 ? p[7].Trim() : ""
            };
        }

        public override string ToString()
        {
            return string.Format("{0,2}: {1} {2} [{3}] - {4:C0}, Питомец: {5}, Оружие: {6}, Логин: {7}",
                Id, FName, LName, Department, Salary, HasPet, HasWeapon ? "Да" : "Нет",
                string.IsNullOrEmpty(Login) ? "<НЕТ>" : Login);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

#if !DEBUG
            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(@"lr11_output.txt", false, Encoding.UTF8);
            Console.SetOut(new_out);
#endif

            Console.WriteLine("==========================================================");
            Console.WriteLine("   ЛАБОРАТОРНАЯ РАБОТА №11: ОБРАБОТКА ДАННЫХ И LINQ       ");
            Console.WriteLine("   Вариант 7: Анализ списка сотрудников предприятия       ");
            Console.WriteLine("==========================================================\n");

            string filePath = "employees.csv";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл " + filePath + " не найден!");
                return;
            }

            List<Employee> list = new List<Employee>();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string header = sr.ReadLine(); // пропускаем заголовок
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(Employee.Create(line));
                    }
                }
            }

            Console.WriteLine("Всего загружено сотрудников: {0}\n", list.Count);

            // 1. Количество сотрудников без логина
            int noLoginCount = list.Count(e => string.IsNullOrEmpty(e.Login));
            Console.WriteLine("--- Задание 1: Сотрудники без логина ---");
            Console.WriteLine("Количество сотрудников без логина: {0}\n", noLoginCount);

            // 2. Средняя заработная плата по каждому из 4-х отделов
            Console.WriteLine("--- Задание 2: Средняя заработная плата по отделам ---");
            var deptAverages = list
                .GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
                .OrderByDescending(d => d.AvgSalary);

            foreach (var item in deptAverages)
            {
                Console.WriteLine("  Отдел: {0,-15} | Средняя з/п: {1:C2}", item.Department, item.AvgSalary);
            }
            Console.WriteLine();

            // 3. Максимальная з/п сотрудников, у которых есть собака или кошка
            var petEmployees = list.Where(e => e.HasPet == "Собака" || e.HasPet == "Кошка").ToList();
            double maxPetSalary = petEmployees.Any() ? petEmployees.Max(e => e.Salary) : 0;
            Console.WriteLine("--- Задание 3: Максимальная з/п владельцев собак/кошек ---");
            Console.WriteLine("Владельцев животных в штате: {0}", petEmployees.Count);
            Console.WriteLine("Максимальная заработная плата: {0:C2}\n", maxPetSalary);

            // 4. Средняя з/п у сотрудников с оружием и без
            var withWeapon = list.Where(e => e.HasWeapon).ToList();
            var withoutWeapon = list.Where(e => !e.HasWeapon).ToList();

            double avgWithWeapon = withWeapon.Any() ? withWeapon.Average(e => e.Salary) : 0;
            double avgWithoutWeapon = withoutWeapon.Any() ? withoutWeapon.Average(e => e.Salary) : 0;

            Console.WriteLine("--- Задание 4: Средняя з/п с оружием и без оружия ---");
            Console.WriteLine("  Сотрудники с оружием (чел: {0,-2}):    средняя з/п = {1:C2}", withWeapon.Count, avgWithWeapon);
            Console.WriteLine("  Сотрудники без оружия (чел: {0,-2}):   средняя з/п = {1:C2}", withoutWeapon.Count, avgWithoutWeapon);
            Console.WriteLine("==========================================================");

#if !DEBUG
            Console.SetOut(save_out);
            new_out.Close();
#else
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
#endif
        }
    }
}
