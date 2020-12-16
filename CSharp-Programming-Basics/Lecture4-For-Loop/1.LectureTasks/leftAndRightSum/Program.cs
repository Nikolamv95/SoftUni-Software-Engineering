using System;
using System.Security.Cryptography;

namespace leftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;


            for (int i = 0; i < n; i++)
            {
                int number1 = int.Parse(Console.ReadLine());

                leftSum += number1;  
            }

            for (int i = 0; i < n; i++)
            {
                int number2 = int.Parse(Console.ReadLine());

                rightSum += number2;
            }

            int difference = 0;

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else if (leftSum > rightSum)
            {
                difference = leftSum - rightSum;
                Console.WriteLine($"No, diff = {difference}");
            }
            else if (leftSum < rightSum)
            {
                difference = rightSum - leftSum;
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
