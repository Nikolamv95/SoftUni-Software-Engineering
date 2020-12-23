using System;

namespace рefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            int digits = 0;
            bool isSpecial = false;
            
            for (int number = 1; number <= input; number++)
            {
                digits = number;
                
                while (number > 0)
                {
                    sumOfDigits += number % 10;
                    number = number / 10;
                }

                
                isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                
                Console.WriteLine($"{digits} -> {isSpecial}");
                
                sumOfDigits = 0;
                number = digits;
            }

        }
    }
}
