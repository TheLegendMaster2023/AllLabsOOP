using System;
using System.IO;

namespace LR7_Demo
{
    public class Par
    {
        private double a, b, c;

        public Par() { a = 1; b = 1; c = 1; }
        public Par(double pA, double pB, double pC)
        {
            a = pA; b = pB; c = pC;
        }

        public static Par CreateParFromFile()
        {
            double aa = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            double bb = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            double cc = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            return new Par(aa, bb, cc);
        }

        public double GetV() { return a * b * c; }
        public double GetS() { return 2 * (a * b + b * c + a * c); }

        public void Info()
        {
            string str =
                "****************************************\n" +
                "*           параллелепипед             *\n" +
                "****************************************";
            Console.WriteLine(str);
            Console.WriteLine(string.Format("A = {0:0.00}, B = {1:0.00}, C = {2:0.00}", a, b, c));
            Console.WriteLine(string.Format("V = {0:0.00}", GetV()));
            Console.WriteLine(string.Format("S = {0:0.00}", GetS()));
        }

        public void Info(ConsoleColor fg, ConsoleColor bg)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Info();
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"par_output.txt");
            var new_in = new StreamReader(@"par_input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            Par p1 = Par.CreateParFromFile();
            p1.Info();

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
#else
            Par p2 = new Par(5.7, 11, 18);
            p2.Info(ConsoleColor.Yellow, ConsoleColor.Blue);
            if (!Console.IsInputRedirected) Console.ReadKey();
#endif
        }
    }
}
