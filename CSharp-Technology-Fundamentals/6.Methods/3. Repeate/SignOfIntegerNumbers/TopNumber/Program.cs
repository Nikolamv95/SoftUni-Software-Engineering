using System;

namespace topNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTopNumber(number);
        }

        static void PrintTopNumber(int number)
        {


            for (int i = 1; i <= number; i++)
            {
                int sum = 0;
                int newNum = i;
                bool oddDigit = false;

                while (newNum != 0)
                {
                    if (newNum == 0)
                    {
                        break;
                    }

                    int right = newNum % 10;
                    sum += right;

                    if (right % 2 != 0)
                    {
                        oddDigit = true;
                    }

                    newNum /= 10;
                }

                if (sum % 8 == 0 && oddDigit == true)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
