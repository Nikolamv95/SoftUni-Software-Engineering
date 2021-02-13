using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, (x, y) =>
            (x % 2 == 0 && y % 2 != 0) ? -1 :
            (x % 2 != 0 && y % 2 == 0) ? 1 :
            x.CompareTo(y));

            //Или
            //{
            //    int sorter = 0;
            //    if (x % 2 == 0 && y % 2 != 0)
            //    {
            //        sorter = -1;
            //    }
            //    else if (x % 2 != 0 && y % 2 == 0)
            //    {
            //        sorter = 1;
            //    }
            //    else
            //    {
            //        sorter = x.CompareTo(y);
            //    }
            //    return sorter;
            //});

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
