using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            char[,] squareMatrix = new char[squareSize, squareSize];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = input[col];
                }
            }
            ;
            char charToFind = char.Parse(Console.ReadLine());
            int curRow = 0;
            int curCol = 0;
            bool isEntered = false;

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    char currChar = squareMatrix[row, col];

                    if (currChar==charToFind)
                    {
                        curRow = row;
                        curCol = col;
                        isEntered = true;
                        break;
                    }
                }

                if (isEntered)
                {
                    break;
                }
            }

            if (isEntered)
            {
                Console.WriteLine($"({curRow}, {curCol})");
            }
            else
            {
                Console.WriteLine($"{charToFind} does not occur in the matrix");
            }
        }
    }
}
