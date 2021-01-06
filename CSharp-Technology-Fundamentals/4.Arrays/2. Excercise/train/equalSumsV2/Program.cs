using System;
using System.Linq;

namespace equalSumsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            bool found = false;

            for (int curIndex = 0; curIndex < array.Length; curIndex++)
            {
                int rightSum = 0;
                for (int i = curIndex + 1; i < array.Length; i++)
                {
                    rightSum += array[i];
                }

                int leftSum = 0;
                for (int j = curIndex - 1; j >= 0; j--)
                {
                    leftSum += array[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(curIndex);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("no");
            }


        }
    }
}
