﻿using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = Calculation(num1, num2, num3);
            Console.WriteLine(result);
        }

        private static int Calculation(int num1, int num2, int num3)
        {
            int result = 0;

            if (num1 <= num2 && num1 <= num3)
            {
                result = num1;
            }
            else if (num2 <= num1 && num2 <= num3)
            {
                result = num2;
            }
            else if (num3 <= num1 && num3 <= num2)
            {
                result = num3;
            }

            return result;
        }
    }
}
