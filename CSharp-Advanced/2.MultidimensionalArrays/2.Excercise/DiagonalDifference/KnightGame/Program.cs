using System;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int z = 0; z < matrix.GetLength(1); z++)
                {
                    matrix[i, z] = input[z];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxAttackedKnights = 0;
                int maxAttackedKnightRow = -1;
                int maxAttackedKnightCol = -1;


                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currChar = matrix[row, col];

                        if (currChar == 'K')
                        {
                            int currAttackedKnights = GetCountAttackedKnight(matrix, row, col);

                            if (currAttackedKnights > maxAttackedKnights)
                            {
                                maxAttackedKnights = currAttackedKnights;
                                maxAttackedKnightRow = row;
                                maxAttackedKnightCol = col;
                            }
                        }
                    }
                }

                if (maxAttackedKnights == 0)
                {
                    break;
                }

                matrix[maxAttackedKnightRow, maxAttackedKnightCol] = '0';
                counter++;
            }
            Console.WriteLine(counter);
        }

        static int GetCountAttackedKnight(char[,] matrix, int row, int col)
        {
            int counter = 0;
            int n = matrix.GetLength(0);

            //Row1
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row-2, col-1] == 'K')
            {
                counter++;
            }
            //Row1
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                counter++;
            }
            //Row2
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                counter++;
            }
            //Row2
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                counter++;
            }
            //Row4
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                counter++;
            }
            //Row4
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                counter++;
            }
            //Row5
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                counter++;
            }
            //Row5
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                counter++;
            }


            return counter;
        }
    }
}
