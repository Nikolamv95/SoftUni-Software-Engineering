using System;

namespace sumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;

            while (input > 0)
            {
                sumOfDigits += input % 10;
                input /= 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
