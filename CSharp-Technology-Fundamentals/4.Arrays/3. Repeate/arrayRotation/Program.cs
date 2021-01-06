using System;
using System.Collections.Generic;
using System.Linq;

namespace arrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            int rotation = int.Parse(Console.ReadLine());

            int counter = 1;

            while (counter <= rotation)
            {
                list.Add(list[0]);
                list.RemoveAt(0);
                counter += 1;
            }
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
