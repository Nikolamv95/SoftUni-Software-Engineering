
using System;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = Calculation(number);
            Console.WriteLine(result);
        }

        private static string Calculation(int number)
        {
            string result = String.Empty;


            if (number == 0)
            {
                result = $"The number {number} is zero.";
            }
            else if (number % 2 == 0)
            {
                result = $"The number {number} is positive.";
            }
            else if (number % 2 != 0)
            {
                result = $"The number {number} is negative.";
            }

            return result;
        }
    }
}
