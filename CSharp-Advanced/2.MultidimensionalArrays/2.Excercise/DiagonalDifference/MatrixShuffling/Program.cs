using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] array = new string[numbers[0], numbers[1]];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int z = 0; z < array.GetLength(1); z++)
                {
                    array[i, z] = input[z];
                }
            }

            string currInput = string.Empty;

            while ((currInput = Console.ReadLine()) != "END")
            {
                string[] data = currInput.Split().ToArray();
                string operation = data[0];

                if (operation != "swap" || data.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    //Curr cordinates
                    int curRow = int.Parse(data[1]);
                    int curCol = int.Parse(data[2]);
                    //Cordinates to swap
                    int rowToChange = int.Parse(data[3]);
                    int colToChange = int.Parse(data[4]);
                    //CheckCordinates
                    if ((curRow >= 0 && curRow < array.GetLength(0)) 
                     && (curCol >= 0 && curCol < array.GetLength(1)) 
                     && (rowToChange >= 0 && rowToChange < array.GetLength(0))
                     && (colToChange >= 0 && colToChange < array.GetLength(1)))
                    {
                        //Take values
                        string currValue = array[curRow, curCol];
                        string valueToChange = array[rowToChange, colToChange];
                        //Swap
                        array[curRow, curCol] = valueToChange;
                        array[rowToChange, colToChange] = currValue;
                        //Print
                        for (int row = 0; row < array.GetLength(0); row++)
                        {
                            for (int col = 0; col < array.GetLength(1); col++)
                            {
                                Console.Write($"{array[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
            }
        }
    }
}
