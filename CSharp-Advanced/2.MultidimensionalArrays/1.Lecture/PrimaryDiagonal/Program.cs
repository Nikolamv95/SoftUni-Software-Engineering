using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[squareSize, squareSize];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                                            .Split(' ')
                                            .Select(int.Parse)
                                            .ToArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = input[col];
                }
            }

            int sum = 0;
            int counter = 0;

            for (int col = 0; col < squareMatrix.GetLength(0); col++)
            {
                for (int row = 0; row < squareMatrix.GetLength(1); row++)
                {
                    if (col == row)
                    {
                        sum += squareMatrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
