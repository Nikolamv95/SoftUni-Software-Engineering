using System;

namespace poundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());

            decimal sum = pound * 1.31M;

            Console.WriteLine($"{sum:f3}");

        }
    }
}
