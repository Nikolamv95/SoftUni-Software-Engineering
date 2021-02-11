using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> myParse = x => int.Parse(x);
            int[] numsInput = Console.ReadLine().Split(' ').Select(myParse).ToArray();

            Func<int[], int> smallestNums = CheckSmallestNum(numsInput);
            Console.WriteLine(smallestNums(numsInput)); 
        }

        static Func<int[], int> CheckSmallestNum(int[] num)
        {
            int smallestNum = int.MaxValue;

            foreach (var item in num)
            {
                if (item < smallestNum)
                {
                    smallestNum = item;
                }
            }

            return nums => smallestNum;
        }
    }
}
