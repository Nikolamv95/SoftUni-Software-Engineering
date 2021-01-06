using System;
using System.Collections.Generic;

namespace commonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] line2 = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = 0; i < line1.Length; i++)
            {
                for (int j = 0; j < line2.Length; j++)
                {
                    if (line1[i] == line2[j])
                    {
                        result.Add(line1[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
