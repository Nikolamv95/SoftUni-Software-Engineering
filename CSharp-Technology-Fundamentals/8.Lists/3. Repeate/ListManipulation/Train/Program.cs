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
            while (operation[0] != "end")
            {
                switch (operation[0])
                {
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

            return output;
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
            numbersToUse.Where(even => even % 2 == 0);
            output.AppendLine(string.Join(' ', numbersToUse));
        }

        private static void PrintOdd(List<int> numbersToUse, StringBuilder output)
        {
            numbersToUse.Where(even => even % 2 != 0);
            output.AppendLine(string.Join(' ', numbersToUse));
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
                numbersToUse.FindAll(num => num > numContains);
                output.AppendLine(string.Join(' ', numbersToUse));
            }
            else if (operation[1] == ">=")
            {
                int numContains = int.Parse(operation[2]);
                numbersToUse.FindAll(num => num >= numContains);
                output.AppendLine(string.Join(' ', numbersToUse));
            }
            else if (operation[1] == "<")
            {
                int numContains = int.Parse(operation[2]);
                numbersToUse.FindAll(num => num < numContains);
                output.AppendLine(string.Join(' ', numbersToUse));
            }
            else if (operation[1] == "<=")
            {
                int numContains = int.Parse(operation[2]);
                numbersToUse.FindAll(num => num <= numContains);
                output.AppendLine(string.Join(' ', numbersToUse));
            }
        }
    }
}
