using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] array = new int[rows, rows];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int z = 0; z < rows; z++)
                {
                    array[i, z] = numbers[z];
                }
            }

            //Sum First Diagonal

            int sumFirstDiag = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int z = 0; z < array.GetLength(1); z++)
                {
                    if (i == z)
                    {
                        sumFirstDiag += array[i, z];
                    }
                }
            }

            //Sum Second DIagonal

            int sumSecDiag = 0;
            int numInMatrix = array.GetLength(1) - 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sumSecDiag += array[i, numInMatrix];
                numInMatrix--;
            }

            Console.WriteLine($"{Math.Abs(sumFirstDiag - sumSecDiag)}");
        }
    }
}
