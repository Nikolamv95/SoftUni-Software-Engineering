using System;
using System.Linq;

namespace sumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            int[] matchedItems = Array.FindAll(input, even=> even % 2 == 0);
            int sum = 0;

            foreach (var numbers in matchedItems)
            {
                sum += numbers;
            }

            Console.WriteLine(sum);
        }
    }
}
