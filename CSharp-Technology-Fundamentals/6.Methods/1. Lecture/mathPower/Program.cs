using System;
using System.Reflection.Metadata.Ecma335;

namespace mathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = 0;

            result = Calculations(number, power);
            Console.WriteLine(result);
        }

        static double Calculations(double number, double power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
