using System;

namespace specialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int sumNumber = 0;

                while (number > 0)
                {
                    sumNumber += number % 10;
                    number = number / 10;
                }

                bool special = ((sumNumber == 5) || (sumNumber == 7) || (sumNumber == 11));

                Console.WriteLine($"{i} -> {special}");
            }
        }
    }
}
