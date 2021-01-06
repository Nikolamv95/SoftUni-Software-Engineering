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

            int[] matchedEven = Array.FindAll(input, even => even % 2 == 0);
            int sumEven = 0;
            foreach (var numbers1 in matchedEven)
            {
                sumEven += numbers1;
            }

            int[] matchedOdd = Array.FindAll(input, odd => odd % 2 != 0);
            int sumOdd = 0;
            foreach (var numbers2 in matchedOdd)
            {
                sumOdd += numbers2;
            }

            Console.WriteLine(sumEven-sumOdd);
        }
    }
}
