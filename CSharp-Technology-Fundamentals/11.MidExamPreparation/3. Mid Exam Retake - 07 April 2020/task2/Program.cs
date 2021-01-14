using System;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] shootTargets = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < shootTargets.Length)
                {
                    if (shootTargets[index] != -1)
                    {
                        int currIndexValue = shootTargets[index];
                        shootTargets[index] = -1;
                        counter++;

                        for (int i = 0; i < shootTargets.Length; i++)
                        {
                            if (shootTargets[i] != -1 && shootTargets[i] > currIndexValue)
                            {
                                shootTargets[i] -= currIndexValue;
                            }
                            else if (shootTargets[i] != -1 && shootTargets[i] <= currIndexValue)
                            {
                                shootTargets[i] += currIndexValue;
                            }
                        }
                    }

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(' ', shootTargets)}");
        }  
    }
}
