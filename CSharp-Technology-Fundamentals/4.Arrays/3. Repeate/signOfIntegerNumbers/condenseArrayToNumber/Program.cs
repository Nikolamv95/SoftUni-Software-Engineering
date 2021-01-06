using System;
using System.Linq;

namespace condenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();
            bool isEntered = false;
            if (line1.Length > 1)
            {
                for (int i = 0; i < line1.Length; i++)
                {
                    int[] condensed = new int[line1.Length - 1];
                    for (int j = 0; j < condensed.Length; j++)
                    {
                        condensed[j] = line1[j] + line1[j + 1];
                    }
                    line1 = condensed;
                    i = 0;
                    isEntered = true;
                }
            }

            if (isEntered)
            {
                Console.WriteLine(line1[0]);
            }
            else
            {
                Console.WriteLine(line1[0]);
            }
        }
    }
}
