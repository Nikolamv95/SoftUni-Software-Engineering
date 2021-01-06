using System;
using System.Linq;

namespace reverseArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

            Console.Write(array);
        }
    }
}
