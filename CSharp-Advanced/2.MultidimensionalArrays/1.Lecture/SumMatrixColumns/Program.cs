using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] currRow = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int sum = 0;
            
            for (int col = 0; col < size[1]; col++)
            {//6
                for (int row = 0; row < size[0]; row++)
                {//3
                    sum += matrix[row, col];
                }               // 3,   6
                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
