using System;
using System.Collections.Generic;
using System.Linq;

namespace bombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            string[] operation = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            int bombNumber = int.Parse(operation[0]);
            int power = int.Parse(operation[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (bombNumber == numbers[i])
                {
                    int startIndex = i - power;
                    int endIndex = i + power;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    int counter = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, counter);
                    i = 0;
                }
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
