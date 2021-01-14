using System;
using System.Collections.Generic;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string operation = data[0];

                switch (operation)
                {
                    case "swap":
                        int index1 = int.Parse(data[1]);
                        int index2 = int.Parse(data[2]);
                        int number1 = listOfNumbers[index1];
                        int number2 = listOfNumbers[index2];

                        listOfNumbers.Insert(index1, number2);
                        listOfNumbers.RemoveAt(index1 + 1);
                        listOfNumbers.Insert(index2, number1);
                        listOfNumbers.RemoveAt(index2 + 1);
                        break;
                    case "multiply":
                        index1 = int.Parse(data[1]);
                        index2 = int.Parse(data[2]);
                        number1 = listOfNumbers[index1];
                        number2 = listOfNumbers[index2];

                        int numToInsert = number1 * number2;

                        listOfNumbers.Insert(index1, numToInsert);
                        listOfNumbers.RemoveAt(index1 + 1);
                        break;
                    case "decrease":
                        for (int i = 0; i < listOfNumbers.Count; i++)
                        {
                            listOfNumbers[i] -= 1;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", listOfNumbers));
        }
    }
}
