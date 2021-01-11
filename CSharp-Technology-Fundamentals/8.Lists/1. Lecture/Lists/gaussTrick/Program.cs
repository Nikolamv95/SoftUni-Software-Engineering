using System;
using System.Collections.Generic;
using System.Linq;

namespace gaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            Calculation(numbers);
        }

        private static void Calculation(List<int> numbers)
        {
            for (int firstNum = 0; firstNum < numbers.Count - 1; firstNum++)
            {
                for (int lastNum = numbers.Count - 1; lastNum > 0; lastNum--)
                {
                    numbers[firstNum] += numbers[lastNum];
                    numbers.RemoveAt(lastNum);
                    break;
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
