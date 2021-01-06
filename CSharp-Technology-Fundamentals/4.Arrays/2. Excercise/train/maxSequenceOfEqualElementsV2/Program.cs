using System;

namespace maxSequenceOfEqualElementsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                             .Split();

            int bestCount = 0;
            int bestIndex = 0;

            for (int index = 0; index < array.Length; index++)
            {
                string currNum = array[index];
                int counterCurr = 1;
                
                for (int j = index + 1; j < array.Length; j++)
                {
                    if (currNum == array[j])
                    {
                        counterCurr += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counterCurr > bestCount)
                {
                    bestCount = counterCurr;
                    bestIndex = index;
                }
            }

            for (int i = 0; i < bestCount; i++)
            {
                string output = array[bestIndex];
                Console.Write($"{output} ");
            }
        }
    }
}
