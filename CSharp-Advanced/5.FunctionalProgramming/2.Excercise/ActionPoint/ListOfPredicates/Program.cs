using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> listDeviders = Console.ReadLine()
                                                       .Split()
                                                       .Select(int.Parse)
                                                       .ToList();
            List<int> numbers = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                bool isdevisible = true;

                foreach (var item in listDeviders)
                {
                    Predicate<int> predicate = x => x % item != 0;

                    if (predicate(i))
                    {
                        isdevisible = false;
                    }
                }

                if (isdevisible)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
