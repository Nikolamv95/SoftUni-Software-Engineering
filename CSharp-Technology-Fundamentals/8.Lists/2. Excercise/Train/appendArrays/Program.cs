using System;
using System.Collections.Generic;
using System.Linq;

namespace appendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                                  .Split("|")
                                  .ToList();
            list.Reverse();

            List<string> result = new List<string>();

            foreach (string currentNum in list)
            {
                string[] numbers = currentNum
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                foreach (string numbersToAdd in numbers)
                {
                    result.Add(numbersToAdd);
                }
            }
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
