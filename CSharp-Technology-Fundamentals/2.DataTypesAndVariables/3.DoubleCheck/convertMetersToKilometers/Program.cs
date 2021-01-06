using System;

namespace convertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal metters = int.Parse(Console.ReadLine());

            metters /= 1000;

            Console.WriteLine($"{metters:f2}");

        }
    }
}
