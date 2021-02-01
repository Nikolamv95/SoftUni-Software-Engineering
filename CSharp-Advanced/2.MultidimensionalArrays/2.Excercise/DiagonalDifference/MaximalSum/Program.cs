using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] array = new int[numbers[0], numbers[1]];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int z = 0; z < array.GetLength(1); z++)
                {
                    array[i, z] = input[z];
                }
            }

            int sum = 0;
            int bestSum = int.MinValue;
            int[,] bestArray = new int[3, 3];

            for (int i = 0; i < array.GetLength(0) - 2; i++)
            {
                for (int z = 0; z < array.GetLength(1) - 2; z++)
                {
                    sum = array[i, z] + array[i, z + 1] + array[i, z + 2]
                        + array[i + 1, z] + array[i + 1, z + 1] + array[i + 1, z + 2]
                        + array[i + 2, z] + array[i + 2, z + 1] + array[i + 2, z + 2];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestArray[0, 0] = array[i, z];
                        bestArray[0, 1] = array[i, z + 1];
                        bestArray[0, 2] = array[i, z + 2];

                        bestArray[1, 0] = array[i + 1, z];
                        bestArray[1, 1] = array[i + 1, z + 1];
                        bestArray[1, 2] = array[i + 1, z + 2];

                        bestArray[2, 0] = array[i + 2, z];
                        bestArray[2, 1] = array[i + 2, z + 1];
                        bestArray[2, 2] = array[i + 2, z + 2];
                    }
                } 
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int row = 0; row < bestArray.GetLength(0); row++)
            {
                for (int col = 0; col < bestArray.GetLength(1); col++)
                {
                    Console.Write($"{bestArray[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}