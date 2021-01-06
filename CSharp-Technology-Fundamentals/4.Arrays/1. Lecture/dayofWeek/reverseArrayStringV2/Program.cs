using System;
using System.Linq;

namespace reverseArrayStringV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine()
                              .Split()
                              .Reverse()));
        }
    }
}
