using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int [] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stackOfNums = new Stack<int>();

            int pushN = rowData[0];
            int popS = rowData[1];
            int numToFind = rowData[2];

            for (int i = 0; i < pushN; i++)
            {
                stackOfNums.Push(sequence[i]);
            }

            bool isNull = false;
            for (int i = 0; i < popS; i++)
            {
                stackOfNums.Pop();

                if (stackOfNums.Count <= 0)
                {
                    isNull = true;
                    break;
                }
            }

            if (isNull == false)
            {
                if (stackOfNums.Contains(numToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int[] newSequence = stackOfNums.ToArray();
                    int num = newSequence.Min();
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
            
        }
    }
}
