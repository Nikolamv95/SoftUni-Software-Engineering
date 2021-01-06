using System;
using System.Linq;

namespace evenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int oddOrEven = array[i];

                if (oddOrEven % 2 == 0)
                {
                    sumEven += oddOrEven;
                }
                else
                {
                    sumOdd += oddOrEven;
                }
            }

            int result = sumEven - sumOdd;

            Console.WriteLine($"{result}");
        }
    }
}
