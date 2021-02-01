using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToArray();
            }

            string command = string.Empty;

            while ((command = Console.ReadLine())!= "END")
            {
                string [] data = command.Split(' ')
                                        .ToArray();

                string operation = data[0];
                int row = int.Parse(data[1]);
                int rowIndex = int.Parse(data[2]);
                int number = int.Parse(data[3]);

                //1 - Проверяваме дали row(броя редове) не е по-малък от 0
                //2 - Проверяваме дали row(броя редове) не е по-голям от броя на редовете в масива
                //3 - Проверяваме дали rowIndex(дължината на конкретния ред) не е по-малък от 0
                //4 - Проверяваме дали rowIndex(дължината на конкретния ред) не е по-голям от максималната дължина на конкретния ред
                if (row < 0 || row >= rows || rowIndex < 0 || rowIndex >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (operation)
                {
                    case "Add":
                        if (matrix[row].Length > row || matrix[rowIndex].Length > rowIndex)
                        {
                            matrix[row][rowIndex] += number;
                        }
                        break;
                    case "Subtract":
                        if (matrix[row].Length > row || matrix[rowIndex].Length > rowIndex)
                        {
                            matrix[row][rowIndex] -= number;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid coordinates");
                        }
                        break;
                    default:
                        Console.WriteLine("Dont exist operation");
                        break;
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
    }
}
