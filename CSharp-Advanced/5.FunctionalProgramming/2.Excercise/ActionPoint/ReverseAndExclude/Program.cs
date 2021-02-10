using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisibleNum = int.Parse(Console.ReadLine());
            numbers.Reverse();
            Func<int, bool> customSubtract = x => x % divisibleNum != 0;
            numbers = numbers.Where(customSubtract).ToList();
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
