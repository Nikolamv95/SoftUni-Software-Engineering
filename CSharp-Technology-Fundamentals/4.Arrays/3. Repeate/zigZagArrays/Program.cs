using System;
using System.Collections.Generic;

namespace zigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> line1 = new List<string>();
            List<string> line2 = new List<string>();

            for (int i = 1; i <= lines; i++)
            {
                string[] numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (i % 2 != 0)
                {
                    line1.Add(numbers[0]);
                    line2.Add(numbers[1]);
                }
                else
                {
                    line1.Add(numbers[1]);
                    line2.Add(numbers[0]);
                }
            }
            Console.WriteLine(string.Join(' ', line1));
            Console.WriteLine(string.Join(' ', line2));
        }
    }
}
