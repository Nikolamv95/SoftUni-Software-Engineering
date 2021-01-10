using System;

namespace calculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double result = Calculations(width, height);
            Console.WriteLine(result);
        }

        private static double Calculations(double widht, double height)
        {
            double result = widht * height;
            return result;
        }
    }
}
