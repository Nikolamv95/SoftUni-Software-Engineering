using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numSequence = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            int capacity = int.Parse(Console.ReadLine());
            Stack<int> stackOfChlotes = new Stack<int>(numSequence);

            int counter = 0;

            while (stackOfChlotes.Count > 0)
            {
                int currValue = 0;

                while (currValue + stackOfChlotes.Peek() <= capacity)
                {
                    currValue += stackOfChlotes.Pop();

                    if (stackOfChlotes.Count == 0)
                    {
                        break;
                    }
                }
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
