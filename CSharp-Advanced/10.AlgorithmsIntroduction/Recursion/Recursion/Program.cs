using System;
using System.Collections.Generic;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int result = Pow(x, n);
            Console.WriteLine(result);

            int[] array = new int[] { 1, 2, 3 };
            Traverse(array, 0);

        }

        static void Traverse<T>(T[] collection, int index)
        {

            if (index == collection.Length)
            {
                return;
            }

            Console.WriteLine(collection[index]);
            Traverse(collection, index + 1);

        }

        private static int Pow(int x, int n)
        {
            if (n == 1)
            {
                return x;
            }

            int current = x * Pow(x, n - 1);
            return current;
        }
    }
}
