using System;
using System.Collections.Generic;
using System.Linq;

namespace topIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                bool isBigger = true;
                int numToCompare = list[i];
                for (int j = i+1; j < list.Count; j++)
                {
                    if (numToCompare <= list[j])
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                {
                    result.Add(numToCompare);
                }
            }
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
