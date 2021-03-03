using System;
using System.Linq;

namespace BruthForceCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 0 };
            GetAllNums(nums, 0);
        }

        static void GetAllNums(int[] nums, int index)
        {
            Console.WriteLine(string.Join(",", nums));
            //if (nums.All(n=> n == 9))
            //{
            //    return;
            //}

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 9)
                {
                    nums[i]++;
                    GetAllNums(nums, index++);
                    nums[i]--;
                }  
            }
        }
    }
}
