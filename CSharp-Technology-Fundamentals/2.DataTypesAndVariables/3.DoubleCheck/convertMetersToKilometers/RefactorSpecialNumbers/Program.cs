using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            int digits = 0;
            bool isSpecial = false;

            for (int i = 1; i <= input; i++)
            {
                digits = i;

                while (i > 0)
                {
                    sumOfDigits += i % 10;
                    i /= 10;
                }

                isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);

                Console.WriteLine($"{digits} -> {isSpecial}");

                sumOfDigits = 0;
                i = digits;
            }

        }
    }
}
