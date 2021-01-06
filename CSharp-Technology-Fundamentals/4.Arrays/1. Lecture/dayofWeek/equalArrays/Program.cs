using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace equalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int[] array2 = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int sumOfArrays = 0;
            int index = 0;
            bool enter = true;

            for (int i = 0; i < array1.Length; i++)
            {
                index += 1;

                if (array1[i] != array2[i])
                {
                    enter = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {index - 1} index");
                    break;
                }
                else
                {
                    sumOfArrays += array1[i];
                }
            }
            if (enter)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfArrays}");
            }
        }
    }
}
