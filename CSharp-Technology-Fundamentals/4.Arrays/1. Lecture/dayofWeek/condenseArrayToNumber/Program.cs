using System;
using System.Linq;

namespace condenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int[] condensed = new int[array.Length - 1];


            if (array.Length == 1)
            {
                foreach (var item in array)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                while (condensed.Length != -1)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        condensed[i] = array[i] + array[i + 1];
                    }

                    if (condensed.Length == 1)
                    {
                        break;
                    }

                    array = condensed;
                    condensed = new int[array.Length - 1];
                }

                for (int i = 0; i < condensed.Length; i++)
                {
                    Console.WriteLine(condensed[i]);
                }
            }           
        }
    }
}
