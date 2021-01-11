using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersToUse = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            string[] operation = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

            StringBuilder output = new StringBuilder();

            TypedOperation(numbersToUse, operation, output);

            Console.WriteLine(output);
        }

        private static StringBuilder TypedOperation(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            bool isChanged = false;
            while (operation[0] != "end")
            {
                switch (operation[0])
                {
                    case "Add":
                        Add(numbersToUse, operation, output);
                        isChanged = true;
                        break;
                    case "Remove":
                        Remove(numbersToUse, operation, output);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        RemoveAt(numbersToUse, operation, output);
                        isChanged = true;
                        break;
                    case "Insert":
                        Insert(numbersToUse, operation, output);
                        isChanged = true;
                        break;
                    case "Contains":
                        Contains(numbersToUse, operation, output);
                        break;
                    case "PrintEven":
                        PrintEven(numbersToUse, output);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbersToUse, output);
                        break;
                    case "GetSum":
                        GetSum(numbersToUse, output);
                        break;
                    case "Filter":
                        Filter(numbersToUse, operation, output);
                        break;
                }

                operation = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();
            }

            if (isChanged)
            {
              output.AppendLine(string.Join(' ', numbersToUse));
            }

            return output;
        }

        private static void Add(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            int numberToAdd = int.Parse(operation[1]);
            numbersToUse.Add(numberToAdd);
        }

        private static void Remove(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            int numberToRemove = int.Parse(operation[1]);
            numbersToUse.Remove(numberToRemove);
        }

        private static void RemoveAt(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            int indexToRemove = int.Parse(operation[1]);
            numbersToUse.RemoveAt(indexToRemove);
        }

        private static void Insert(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            int indexToInsert = int.Parse(operation[2]);
            int numberToInsert = int.Parse(operation[1]);
            numbersToUse.Insert(indexToInsert, numberToInsert);
        }

        private static void Contains(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            int numContains = int.Parse(operation[1]);

            if (numbersToUse.Contains(numContains))
            {
                output.AppendLine("Yes");
            }
            else
            {
                output.AppendLine("No such number");
            }
        }

        private static void PrintEven(List<int> numbersToUse, StringBuilder output)
        {
            var evenNumbers = numbersToUse.Where(x => x % 2 == 0).ToList();
            output.AppendLine(string.Join(' ', evenNumbers));
        }

        private static void PrintOdd(List<int> numbersToUse, StringBuilder output)
        {
            var oddNumbers = numbersToUse.Where(x => x % 2 != 0).ToList();
            output.AppendLine(string.Join(' ', oddNumbers));
        }

        private static void GetSum(List<int> numbersToUse, StringBuilder output)
        {
            output.AppendLine(String.Join(' ', numbersToUse.Sum()));
        }

        private static void Filter(List<int> numbersToUse, string[] operation, StringBuilder output)
        {
            if (operation[1] == ">")
            {
                int numContains = int.Parse(operation[2]);
                var FilteredNums = numbersToUse.FindAll(num => num > numContains).ToList();
                output.AppendLine(string.Join(' ', FilteredNums));
            }
            else if (operation[1] == ">=")
            {
                int numContains = int.Parse(operation[2]);
                var FilteredNums = numbersToUse.FindAll(num => num >= numContains).ToList();
                output.AppendLine(string.Join(' ', FilteredNums));
            }
            else if (operation[1] == "<")
            {
                int numContains = int.Parse(operation[2]);
                var FilteredNums = numbersToUse.FindAll(num => num < numContains).ToList();
                output.AppendLine(string.Join(' ', FilteredNums));
            }
            else if (operation[1] == "<=")
            {
                int numContains = int.Parse(operation[2]);
                var FilteredNums = numbersToUse.FindAll(num => num <= numContains).ToList();
                output.AppendLine(string.Join(' ', FilteredNums));
            }
        }
    }
}
