using System;
using System.Linq;

namespace topIntegersV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            bool isBigger = true;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] >= currentNumber)
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    Console.WriteLine($"{currentNumber} ");
                }

                isBigger = true;
            }
        }
    }
}
