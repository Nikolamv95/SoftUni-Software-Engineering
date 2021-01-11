using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string[]operation = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

             

            while (operation [0] != "end")
            {

                if (operation[0] == "add")
                {
                    int numberToAdd = int.Parse(operation[1]);
                    numbers.Add(numberToAdd);
                }
                else
                {
                    for (int i = 0; i <numbers.Count; i++)
                    {
                        if (int.Parse(operation[0]) + numbers[i] <= maxCapacity)
                        {
                            int combineNumber = int.Parse(operation[0]) + numbers[i];
                            numbers.Insert(i, combineNumber);
                            numbers.RemoveAt(i + 1);
                            break;
                        }
                    }
                }

                operation = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
