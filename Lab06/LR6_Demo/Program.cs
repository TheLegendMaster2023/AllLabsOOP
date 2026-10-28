using System;
using System.IO;

namespace LR6_Demo
{
    public class Par
    {
        private double a, b, c;

        public double GetV() { return a * b * c; }
        public double GetS() { return 2 * (a * b + b * c + a * c); }

        public void Info()
        {
            string str =
                "****************************************\n" +
                "*                                      *\n" +
                "*           параллелепипед             *\n" +
                "*                                      *\n" +
                "****************************************\n";
            Console.WriteLine(str);
            Console.WriteLine(string.Format("A = {0:0.00}, B = {1:0.00}, C = {2:0.00}", a, b, c));
            Console.WriteLine(string.Format("V = {0:0.00}", GetV()));
            Console.WriteLine(string.Format("S = {0:0.00}", GetS()));
        }

        public void Load()
        {
            a = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            b = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
            c = Convert.ToDouble(Console.ReadLine().Trim().Replace('.', ','));
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

            Par p = new Par();
            p.Load();
            p.Info();

            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
#else
            Par p = new Par();
            p.Load();
            p.Info();
            if (!Console.IsInputRedirected) Console.ReadKey();
#endif
        }
    }
}
