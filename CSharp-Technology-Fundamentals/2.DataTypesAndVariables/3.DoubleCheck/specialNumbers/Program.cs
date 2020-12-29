using System;

namespace specialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberDevide = number;
            int lastNum = 0;
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                numberDevide = i;

                for (int j = 0; j <= numberDevide; j++)
                {
                    lastNum = numberDevide % 10;
                    sum += lastNum;
                    numberDevide /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

                sum = 0;
                
            }
        }
    }
}
