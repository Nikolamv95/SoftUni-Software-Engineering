using System;

namespace addAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = GetSum(num1, num2, num3);
            Console.WriteLine(result);
        }

        private static int GetSum(int num1, int num2, int num3)
        {
            int sum2Integers = num1 + num2;
            int result = GetSubtract(sum2Integers, num3);
            return result;
        }

        private static int GetSubtract(int sum2Integers, int num3)
        {
            int result = sum2Integers - num3;
            return result;
        }
    }
}
