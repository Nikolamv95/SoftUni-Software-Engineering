using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedCars = int.Parse(Console.ReadLine());
            Queue<string> queOfCars = new Queue<string>();
            int counter = 0;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queOfCars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < allowedCars; i++)
                    {
                        if (queOfCars.Count > 0)
                        {
                            counter++;
                            Console.WriteLine($"{queOfCars.Dequeue()} passed!");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
