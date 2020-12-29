using System;

namespace sumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumDigits = 0;

            while (input > 0)
            {
                sumDigits += input % 10;
                input = input / 10;
            }

            Console.WriteLine(sumDigits);
        }
    }
}
