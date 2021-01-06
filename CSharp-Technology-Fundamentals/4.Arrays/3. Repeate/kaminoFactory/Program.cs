using System;
using System.Collections.Generic;
using System.Linq;

namespace kaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int bestLenght = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int sequenceCounter = 0;
            int bestSequenceIndex = 0;
            int[] bestSequence = new int[size];

            while (input != "Clone them!")
            {
                int[] currSequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
                int lenght = 1;
                int bestCurrLenght = 1;
                int startIndex = 0;
                int sumCurrSequence = 0;
                sequenceCounter++;

                for (int i = 0; i < currSequence.Length-1; i++)
                {
                    if (currSequence[i] == currSequence[i+1])
                    {
                        lenght++;
                    }
                    else
                    {
                        lenght = 1;
                    }

                    if (lenght > bestCurrLenght)
                    {
                        bestCurrLenght = lenght;
                        startIndex = i;
                    }
                    sumCurrSequence += currSequence[i];
                }
                sumCurrSequence += currSequence[lenght - 1];

                if (bestCurrLenght > bestLenght)
                {
                    bestLenght = bestCurrLenght;
                    bestStartIndex = startIndex;
                    bestSequenceSum = sumCurrSequence;
                    bestSequenceIndex = sequenceCounter;
                    bestSequence = currSequence.ToArray();
                }
                else if (bestCurrLenght == bestLenght)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestLenght = bestCurrLenght;
                        bestStartIndex = startIndex;
                        bestSequenceSum = sumCurrSequence;
                        bestSequenceIndex = sequenceCounter;
                        bestSequence = currSequence.ToArray();
                    }
                    else if (startIndex == bestStartIndex)
                    {
                        if (sumCurrSequence > bestSequenceSum)
                        {
                            bestLenght = bestCurrLenght;
                            bestStartIndex = startIndex;
                            bestSequenceSum = sumCurrSequence;
                            bestSequenceIndex = sequenceCounter;
                            bestSequence = currSequence.ToArray();
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
