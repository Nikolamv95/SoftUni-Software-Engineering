using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> numOfDic = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double currNum = input[i];

                if (!numOfDic.ContainsKey(currNum))
                {
                    numOfDic.Add(currNum, 1);
                }
                else
                {
                    numOfDic[currNum]++;
                }
            }

            foreach (var item in numOfDic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
