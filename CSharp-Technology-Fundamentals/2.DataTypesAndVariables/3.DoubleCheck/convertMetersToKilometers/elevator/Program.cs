using System;

namespace elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int elevateNPersons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double sum = (double)elevateNPersons / capacity;

            Console.WriteLine($"{Math.Ceiling(sum)}");
        }
    }
}
