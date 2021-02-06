using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<int, int> dicOfNums = new Dictionary<int, int>();

            for (int i = 0; i < rows; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (dicOfNums.ContainsKey(num) == false)
                {
                    dicOfNums.Add(num, 1);
                }
                else
                {
                    dicOfNums[num]++;
                }
            }

            foreach (var item in dicOfNums)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
