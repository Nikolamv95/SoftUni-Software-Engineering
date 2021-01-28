using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string kidNames = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>
                                          (kidNames.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            while (kids.Count > 1)
            {
                for (int i = 1; i < rows; i++)
                {
                    string kid = kids.Dequeue();
                    kids.Enqueue(kid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
