using System;

namespace convertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            decimal km = number / 1000M;

            Console.WriteLine($"{km:f2}");
        }
    }
}
