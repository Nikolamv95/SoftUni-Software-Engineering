using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> people = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    people.Enqueue(input);
                }
                else
                {
                    int numOfPeople = people.Count;
                    for (int i = 0; i < numOfPeople; i++)
                    {
                        Console.WriteLine($"{people.Dequeue()}") ;
                    }
                }
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
