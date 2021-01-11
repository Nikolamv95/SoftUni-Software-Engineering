using System;
using System.Collections.Generic;

namespace houseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            List<string> goingNames = new List<string>(lenght);

            string[] input = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lenght; i++)
            {
                if (input.Length == 4)
                {
                    if (goingNames.Contains(input[0]))
                    {
                        goingNames.RemoveAll(n => n == input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
                else if (input.Length == 3)
                {
                    if (goingNames.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        goingNames.Add(input[0]);
                    }
                }

                if (i < lenght-1)
                {
                    Array.Clear(input, 0, input.Length);
                    input = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, goingNames));
        }
    }
}
