using System;
using System.Linq;

namespace equalSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            bool isFound = false;

            for (int curr = 0; curr < array.Length; curr++)
            {
                int rightSum = 0;

                for (int j = curr + 1; j < array.Length; j++)
                {
                    rightSum += array[j];
                }

                int leftSum = 0;
                for (int k = curr - 1; k >= 0; k--)
                {
                    leftSum += array[k];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(curr);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}