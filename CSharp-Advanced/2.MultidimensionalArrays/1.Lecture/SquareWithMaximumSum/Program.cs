﻿using System;
using System.Linq;

namespace SquareWithMaximumSum
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

            //Пълним матрицата
            for (int row = 0; row < size[0]; row++)
            {
                int[] currRow = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    //1-клетка 1
                    int sum = matrix[row, col];
                    //2-клетката до нея
                    sum += matrix[row, col + 1];
                    //клетката под 1
                    sum += matrix[row + 1, col];
                    //клетката под 2
                    sum += matrix[row + 1, col + 1];

                    //Записваме стойностите на най-голямата намерена сума
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }

            }

            Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
            Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
