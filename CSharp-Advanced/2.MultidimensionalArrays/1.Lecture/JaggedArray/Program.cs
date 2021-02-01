using System;
using System.Linq;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged = new int[3][];//В Първото квадратче се задава размера на основния масив. 
                                          //Второто квадратче се дава размра на вложените масиви, но тъй като са различни
                                          //го оставяме празно
            jagged[0] = new int[3];
            jagged[1] = new int[2];
            jagged[2] = new int[4];

            //Достъпваме и пълним ЕДИН елемент по следния начин
            jagged[0][0] = 1;
            Console.WriteLine($"{jagged[0][0]}");

            //Достъпваме и пълним ЕДИН вложен масив по следния начин
            //пълним ред по ред. За всеки ред отделен for цикъл

            for (int row = 0; row < jagged.Length; row++)
            {
                string[] inputNumbers = Console.ReadLine().Split(' ').ToArray();
                jagged[row] = new int[inputNumbers.Length];

                for (int indexRow = 0; indexRow < jagged[row].Length; indexRow++)
                {
                    jagged[row][indexRow] = int.Parse(inputNumbers[indexRow]);
                }
            }

            //Печатаме назъбен масив по следния начин
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int indexRow = 0; indexRow < jagged[row].Length; indexRow++)
                {
                    Console.WriteLine($"{jagged[row][indexRow]}");
                }
            }

            //или
            foreach(int[]row in jagged)
            {
                Console.WriteLine($"{string.Join(' ', row)}");
            }
            
        }
    }
}
