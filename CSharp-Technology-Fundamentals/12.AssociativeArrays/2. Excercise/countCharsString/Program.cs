using System;
using System.Collections.Generic;
using System.Linq;

namespace countCharsString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace(" ", string.Empty);
            char[] data = input.ToCharArray();

            Dictionary<char, int> numOfChars = new Dictionary<char, int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (numOfChars.ContainsKey(data[i]) == false)
                {
                    numOfChars.Add(data[i], 1);
                }
                else
                {
                    numOfChars[data[i]]++;
                }
            }

            foreach (var item in numOfChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
