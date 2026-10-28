using System;
using System.Text;

namespace LR9_Demo
{
    public interface ICalculate
    {
        void Plus(int pPlus);
        void Minus(int pMinus);
    }

    public interface IVisual
    {
        string Name { get; set; }
        void DrawObject();
    }

    public class Human : ICalculate, IVisual
    {
        public string FIO;
        private int Age;

        public Human(string pFIO, int pAge)
        {
            FIO = pFIO;
            Age = pAge;
        }

        public void Plus(int pPlus) { Age += pPlus; }
        public void Minus(int pMinus) { Age -= pMinus; }

        public string Name
        {
            get { return FIO + " : " + Age.ToString(); }
            set { FIO = value; }
        }

        public void DrawObject()
        {
            Console.WriteLine("    o\n  / | \\\n   / \\\n" + Name);
        }
    }

    public class Car : ICalculate, IVisual
    {
        private string Manufacturer;
        private string Model;
        private int Velocity;

        public Car(string pManufacturer, string pModel, int pVelocity)
        {
            Manufacturer = pManufacturer;
            Model = pModel;
            Velocity = pVelocity;
        }

        public void Plus(int pPlus) { Velocity += pPlus; }
        public void Minus(int pMinus) { Velocity -= pMinus; }

        public string Name
        {
            get { return Manufacturer + " - " + Model + " : " + Velocity.ToString() + " km/h"; }
            set { Model = value; }
        }

        public void DrawObject()
        {
            Console.WriteLine("  .---.\n _/__~_\\_\n(o)---(o)\n" + Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Human h = new Human("Иванов Иван", 50);
            h.Plus(5);
            h.Minus(1);
            h.DrawObject();
            Console.WriteLine();

            Car car = new Car("Hyundai", "ix35", 120);
            car.Plus(25);
            car.Minus(11);
            car.DrawObject();
        }
    }
}
