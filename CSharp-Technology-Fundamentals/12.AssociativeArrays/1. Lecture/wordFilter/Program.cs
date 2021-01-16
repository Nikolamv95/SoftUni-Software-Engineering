using System;
using System.Collections.Generic;
using System.Linq;

namespace wordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> word = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Where(x => x.Length % 2 == 0)
                             .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, word));
        }
    }
}
