using System;
using System.Collections.Generic;
using System.Linq;

namespace maxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            int bestSeq = 0;
            int currCount = 1;
            int number = 0;
           
            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                for (int j = i+1; j < listOfNumbers.Count; j++)
                {
                    if (listOfNumbers[i] == listOfNumbers[j])
                    {
                        currCount += 1;

                        if (currCount > bestSeq)
                        {
                            bestSeq = currCount;
                            number = listOfNumbers[i];
                        } 
                    }
                    else
                    {
                        break;
                    }
                }
                currCount = 1;
            }

            for (int i = 1; i <= bestSeq; i++)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
