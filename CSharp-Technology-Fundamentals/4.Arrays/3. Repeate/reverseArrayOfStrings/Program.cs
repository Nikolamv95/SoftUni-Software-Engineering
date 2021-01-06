using System;
using System.Linq;

namespace reverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(input);
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
