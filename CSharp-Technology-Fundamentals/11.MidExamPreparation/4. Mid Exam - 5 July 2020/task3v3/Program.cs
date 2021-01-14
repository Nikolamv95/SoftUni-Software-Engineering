using System;
using System.Collections.Generic;
using System.Linq;

namespace task3v3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceIntegers = Console
                      .ReadLine()
                      .Split()
                      .Select(int.Parse)
                      .ToList();
            
            var result = sequenceIntegers.Where(x => x > sequenceIntegers.Average()).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine(string.Join(" ", result.OrderByDescending(x => x).Take(Math.Min(5, result.Count))));
        }
    }
}
