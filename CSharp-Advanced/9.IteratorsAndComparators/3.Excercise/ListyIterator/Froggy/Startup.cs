using System;
using System.Linq;

namespace Froggy
{
    class Startup
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake();

            for (int i = 0; i < nums.Length; i++)
            {
                lake.Push(nums[i]);
            }

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
