using System;

namespace centerPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double result1 = FirstResult1(x1, y1);
            double result2 = FirstResult2(x2, y2);

            if (result1 > result2)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }

        private static double FirstResult1(double x1, double y1)
        {
            double result1 = Math.Abs(x1) + Math.Abs(y1);
            return result1;
        }

        private static double FirstResult2(double x2, double y2)
        {
            double result2 = Math.Abs(x2) + Math.Abs(y2);
            return result2;
        }
    }
}
