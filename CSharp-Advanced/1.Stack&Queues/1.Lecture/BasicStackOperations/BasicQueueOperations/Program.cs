﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queueOfNums = new Queue<int>();

            int pushN = rowData[0];
            int popS = rowData[1];
            int numToFind = rowData[2];

            for (int i = 0; i < pushN; i++)
            {
                queueOfNums.Enqueue(sequence[i]);
            }

            bool isNull = false;
            for (int i = 0; i < popS; i++)
            {
                queueOfNums.Dequeue();

                if (queueOfNums.Count <= 0)
                {
                    isNull = true;
                    break;
                }
            }

            if (isNull == false)
            {
                if (queueOfNums.Contains(numToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int[] newSequence = queueOfNums.ToArray();
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
