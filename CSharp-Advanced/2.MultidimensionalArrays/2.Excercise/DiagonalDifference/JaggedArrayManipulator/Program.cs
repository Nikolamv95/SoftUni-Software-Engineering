using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            //Step 1 - Fill the array
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                double[] inputNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArr[i] = inputNumbers;
            }

            //Step 2 - Equal length or not
            for (int i = 0; i < jaggedArr.Length - 1; i++)
            {
                int currRow = jaggedArr[i].Length;
                int nextRow = jaggedArr[i + 1].Length;

                if (currRow == nextRow)
                {
                    jaggedArr[i] = jaggedArr[i].Select(x => x * 2).ToArray();
                    jaggedArr[i + 1] = jaggedArr[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArr[i] = jaggedArr[i].Select(x => x / 2).ToArray();
                    jaggedArr[i + 1] = jaggedArr[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] data = commands.Split().ToArray();
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                double value = double.Parse(data[3]);


                if (ValidateCell(jaggedArr, row, col))
                {
                    if (data[0] == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else
                    {
                        jaggedArr[row][col] -= value;
                    }
                }
            }

            foreach (var item in jaggedArr)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }

        private static bool ValidateCell(double[][] jaggedArr, int row, int col)
        {
            return row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length;
        }
    }
}