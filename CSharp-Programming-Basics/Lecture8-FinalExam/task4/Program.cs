using System;
using System.Collections.Generic;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            List<int> listOfNums = new List<int>();

            for (int i = m; i >= n; i--)
            {
                if ((i % 2 == 0) && (i % 3 == 0))
                {
                    if (i != s)
                    {
                        listOfNums.Add(i);
                    }
                    else
                    {
                        break;
                    }
                    
                    
                }
            }

            Console.WriteLine(string.Join(' ', listOfNums));
        }
    }
}
