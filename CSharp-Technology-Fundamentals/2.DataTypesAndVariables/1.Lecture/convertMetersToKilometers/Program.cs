using System;

namespace convertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            float km = number / 1000F;

            Console.WriteLine($"{km:f2}");
        }
    }
}
