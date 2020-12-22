using System;

namespace strongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int extractNumber = number;
            int factorial = 0;
            int sumOfFactorial = 0;
            int lastNumber = 0;

            while (number != 0)
            {
                lastNumber = number % 10;
                int variable = lastNumber;
                number /= 10;

                if (lastNumber == 0)
                {
                    lastNumber = 1;
                }

                for (int i = 1; i < variable; i++)
                {
                    lastNumber *= i;
                }

                sumOfFactorial += lastNumber;
            }

            if (extractNumber == sumOfFactorial)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }


        }
    }
}
