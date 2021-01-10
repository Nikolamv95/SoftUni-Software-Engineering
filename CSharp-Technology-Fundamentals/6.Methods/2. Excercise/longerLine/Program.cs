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
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double result1 = FirstResult1(x1, y1);
            double result2 = FirstResult2(x2, y2);
            double result3 = FirstResult3(x3, y3);
            double result4 = FirstResult4(x4, y4);

            if (result1 + result2 >= result3 + result4)
            {
                if (result1 > result2)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
            else
            {
                if (result3 > result4)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                
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

        private static double FirstResult3(double x3, double y3)
        {
            double result3 = Math.Abs(x3) + Math.Abs(y3); ;
            return result3;
        }

        private static double FirstResult4(double x4, double y4)
        {
            double result4 = Math.Abs(x4) + Math.Abs(y4);
            return result4;
        }
    }
}
