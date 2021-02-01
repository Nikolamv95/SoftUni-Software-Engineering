using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] array = new char[numbers[0], numbers[1]];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int z = 0; z < array.GetLength(1); z++)
                {
                    array[i, z] = input[z];
                }
            }


            char firstChar;
            char secondChar;
            int sum = 0;

            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int z = 0; z < array.GetLength(1) - 1; z++)
                {
                    firstChar = array[i, z];
                    secondChar = array[i + 1, z + 1];

                    if (firstChar == secondChar)
                    {
                        if (firstChar == array[i, z + 1] && secondChar == array[i + 1, z])
                        {
                            sum++;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}