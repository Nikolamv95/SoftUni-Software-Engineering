using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Stack<int> stackOfNums = new Stack<int>();

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                switch (input[0])
                {
                    case 1: //Psuh
                       int currNum = input[1];
                        stackOfNums.Push(currNum);
                        break;
                    case 2: //Delete
                        if (stackOfNums.Count > 0)
                        {
                            stackOfNums.Pop();
                        }
                        break;
                    case 3: //Max
                        if (stackOfNums.Count > 0)
                        {
                            int maxNum = stackOfNums.Max();
                            Console.WriteLine(maxNum);
                        }
                        break;
                    case 4: //Min
                        if (stackOfNums.Count > 0)
                        {
                            int minNum = stackOfNums.Min();
                            Console.WriteLine(minNum);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stackOfNums));
        }
    }
}
