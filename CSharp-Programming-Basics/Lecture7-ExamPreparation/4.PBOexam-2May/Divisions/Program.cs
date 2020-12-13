using System;

namespace DivisionWithoutRem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfNumber = int.Parse(Console.ReadLine());
            int divBy2 = 0;
            int divBy3 = 0;
            int divBy4 = 0;

            for (int i = 0; i < numOfNumber; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (currNum % 2 == 0)
                {
                    divBy2 += 1;
                }
                if (currNum % 3 == 0)
                {
                    divBy3 += 1;
                }
                if (currNum % 4 == 0)
                {
                    divBy4 += 1;
                }
            }
           ;
        }
    }
}
