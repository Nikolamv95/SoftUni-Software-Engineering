using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();

            SortedDictionary<double, int> listOfNumbers = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (listOfNumbers.ContainsKey(numbers[i]) == false)
                {
                    listOfNumbers.Add(numbers[i], 1);
                }
                else
                {
                    listOfNumbers[numbers[i]]++;
                }
            }

            foreach (var item in listOfNumbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
