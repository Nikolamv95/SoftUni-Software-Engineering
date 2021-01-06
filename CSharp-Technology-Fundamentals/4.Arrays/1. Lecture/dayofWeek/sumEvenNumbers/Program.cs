using System;
using System.Linq;

namespace sumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)   
                           .Select(int.Parse)
                           .ToArray();

            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int oddOrEven = array[i];

                if (oddOrEven % 2 == 0)
                {
                    sum += oddOrEven;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
