using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jaggedArr[i] = new int[inputNumbers.Length];

                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    jaggedArr[i][j] = inputNumbers[j];
                }
            }
            ;
            //Равни и неравни
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                int currRow = jaggedArr[i].Length;
                int nextRow = jaggedArr[i + 1].Length;

                if (currRow == nextRow)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] *= 2;
                    }
                    for (int k = 0; k < jaggedArr[i + 1].Length; k++)
                    {
                        jaggedArr[i + 1][k] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] /= 2;
                    }
                    for (int k = 0; k < jaggedArr[i + 1].Length; k++)
                    {
                        jaggedArr[i + 1][k] /= 2;
                    }
                }
            }
        }
    }
}
