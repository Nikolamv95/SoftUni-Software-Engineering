using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charInput = Console.ReadLine().ToCharArray();
            Dictionary<char, int> dicOfChars = new Dictionary<char, int>();

            for (int i = 0; i < charInput.Length; i++)
            {
                char currChar = charInput[i];

                if (dicOfChars.ContainsKey(currChar) == false)
                {
                    dicOfChars.Add(currChar, 1);
                }
                else
                {
                    dicOfChars[currChar]++;
                }
            }

            foreach (var item in dicOfChars.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
