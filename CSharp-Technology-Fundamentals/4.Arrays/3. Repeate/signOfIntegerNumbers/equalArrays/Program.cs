using System;
using System.Linq;

namespace equalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            int[] line2 = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

            int sum = 0;
            bool isIdentical = true;
            for (int i = 0; i < line1.Length; i++)
            {
                if (line1[i] != line2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isIdentical = false;
                    break;
                }
                else
                {
                    sum += line1[i];
                }
            }
            if (isIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
