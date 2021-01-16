using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            Dictionary<string, int> listOfNumbers = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (listOfNumbers.ContainsKey(input[i]) == false)
                {
                    listOfNumbers.Add(input[i], 1);
                }
                else
                {
                    listOfNumbers[input[i]]++;
                }
            }
            ;
            foreach (var item in listOfNumbers)
            {
                int number = item.Value;

                if (number % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
