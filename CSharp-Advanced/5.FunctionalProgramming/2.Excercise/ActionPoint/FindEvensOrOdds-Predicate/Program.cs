using System;
using System.Linq;

namespace FindEvensOrOdds_Predicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> myParse = x => int.Parse(x);
            int[] nums = Console.ReadLine().Split().Select(myParse).ToArray();
            string oddOrEven = Console.ReadLine();
            int currNum = 0;
            Predicate<int> oddOrEvenPredicate = FindOddOrEven(currNum, oddOrEven);

            for (int i = nums[0]; i <= nums[1]; i++)
            {
                currNum = i;

                if (oddOrEvenPredicate(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }

        static Predicate<int> FindOddOrEven(int currNum, string oddOrEven)
        {
            switch (oddOrEven)
            {
                case "odd": return p => p % 2 != 0;
                case "even": return p => p % 2 == 0;
                default: return null;
            }
        }
    }
}
