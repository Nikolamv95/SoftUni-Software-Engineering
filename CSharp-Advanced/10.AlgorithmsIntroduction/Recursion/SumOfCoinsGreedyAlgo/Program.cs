using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoinsGreedyAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(": ");
            int[] coins = input[1].Split(", ").Select(int.Parse).ToArray();

            string[] input2 = Console.ReadLine().Split(": ");
            int[] sum = input2[1].Split(", ").Select(int.Parse).ToArray();

            Dictionary<int, int> coinsReturned = new Dictionary<int, int>();

            int currChange = 0;
            coins = coins.OrderByDescending(c => c).ToArray();

            while (currChange < sum[0])
            {
                for (int i = 0; i < coins.Length; i++)
                {
                    if (currChange + coins[i] <= sum[0])
                    {
                        currChange += coins[i];

                        if (coinsReturned.ContainsKey(coins[i]) == false)
                        {
                            coinsReturned.Add(coins[i], 1);
                        }
                        else
                        {
                            coinsReturned[coins[i]] += 1;
                        }
                        
                        break;
                    }
                }
            }

            int result = 0;
            foreach (var item in coinsReturned)
            {
                result += item.Value;
            }

            Console.WriteLine($"Number of coins to take: {result}");

            foreach (var item in coinsReturned)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
        }
    }
}
