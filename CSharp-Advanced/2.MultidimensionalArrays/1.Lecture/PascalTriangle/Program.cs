using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long [][] matrix = new long[rows][];
            int currLenght = 1;

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new long[currLenght];
                matrix[i][0] = 1;
                matrix[i][currLenght - 1] = 1;

                for (int j = 1; j < currLenght-1; j++)
                {
                    long firstNum = matrix[i-1][j-1];
                    long seconNUm = matrix[i-1][j];
                    matrix[i][j] = firstNum + seconNUm;
                }
                currLenght++;
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(' ',item));
            }
        }
    }
}
