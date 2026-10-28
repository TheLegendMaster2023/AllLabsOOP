using System;
using System.Text;

namespace LR8_Demo
{
    public enum УченыеЗвания { Доцент, Профессор, Академик, Без_Звания }
    public enum УченыеСтепени { Кандидат_Технических_Наук, Кандидат_ФизМат_Наук, Доктор_ФизМат_Наук, Без_Степени }
    public enum Специальности { Информационные_Системы_И_Технологии, Прикладная_Информатика, Наноэлектроника }

    public class Человек
    {
        public string Фамилия, Имя, Отчество;
        public int Возраст;

        public Человек(string ф, string и, string о, int возр)
        {
            Фамилия = ф; Имя = и; Отчество = о; Возраст = возр;
        }

        public virtual string ФИО
        {
            get { return Фамилия + " " + Имя + " " + Отчество; }
        }
    }

    public class Студент : Человек
    {
        public Специальности Специальность;

        public Студент(string ф, string и, string о, int возр, Специальности спец)
            : base(ф, и, о, возр)
        {
            Специальность = спец;
        }

        public override string ФИО
        {
            get { return base.ФИО + ", " + Специальность.ToString(); }
        }
    }

    public class Учитель : Человек
    {
        public УченыеЗвания УченоеЗвание;
        public УченыеСтепени УченаяСтепень;

        public Учитель(string ф, string и, string о, int возр, УченыеЗвания уз, УченыеСтепени ус)
            : base(ф, и, о, возр)
        {
            УченоеЗвание = уз;
            УченаяСтепень = ус;
        }

        public override string ФИО
        {
            get { return УченаяСтепень.ToString() + ", " + УченоеЗвание.ToString() + ", " + base.ФИО; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Человек[] mas = new Человек[]
            {
                new Человек("Петров", "Петр", "Петрович", 10),
                new Студент("Коробов", "Сергей", "Викторович", 19, Специальности.Прикладная_Информатика),
                new Учитель("Николаев", "Евгений", "Иванович", 30, УченыеЗвания.Доцент, УченыеСтепени.Кандидат_Технических_Наук)
            };

            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(">>>>>>>>> " + mas[i].GetType().Name);
                Console.WriteLine(mas[i].ФИО);
                Console.WriteLine("Возраст: " + mas[i].Возраст + "\n");
            }
        }
    }
}
