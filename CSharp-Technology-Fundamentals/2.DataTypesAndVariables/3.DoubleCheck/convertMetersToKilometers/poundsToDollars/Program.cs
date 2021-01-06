using System;

namespace poundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());
            decimal dollars = 1.31M;
            decimal totalSum = pound * dollars;

            Console.WriteLine($"{totalSum:f3}");
            
        }
    }
}
