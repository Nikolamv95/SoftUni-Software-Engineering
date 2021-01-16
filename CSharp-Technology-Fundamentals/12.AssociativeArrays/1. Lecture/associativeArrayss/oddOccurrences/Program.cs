using System;
using System.Collections.Generic;
using System.Linq;

namespace oddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                              .ToLower()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .ToArray();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var item in input)
            {
                if (!words.ContainsKey(item))
                {
                    words.Add(item, 1);
                }
                else
                {
                    words[item] += 1;
                }
            }

            foreach (var item in words)
            {
                int number = item.Value;

                if ( number % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
