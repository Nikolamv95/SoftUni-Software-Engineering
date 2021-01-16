using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            numbers.Sort();
            List <int> top3 = numbers.TakeLast(3).Reverse().ToList();
            Console.WriteLine(string.Join(' ', top3));
        }
    }
}
