using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> setNumsOne = new HashSet<int>();
            HashSet<int> setNumsTwo = new HashSet<int>();

            int[] rows = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < rows[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setNumsOne.Add(num);
            }
            for (int i = 0; i < rows[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setNumsTwo.Add(num);
            }

            setNumsOne.IntersectWith(setNumsTwo);
            Console.WriteLine(string.Join(' ', setNumsOne));
        }
    }
}
