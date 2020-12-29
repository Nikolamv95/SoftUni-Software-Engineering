using System;
using System.Numerics;

namespace spiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger startingYield = BigInteger.Parse(Console.ReadLine());
            BigInteger yieldLeft = 0;
            BigInteger yieldConsWorkers = 26;
            BigInteger dailyCost = 10;
            BigInteger daysCount = 0;

            if (startingYield < 100)
            {
                Console.WriteLine(daysCount);
                Console.WriteLine(yieldLeft);
            }
            else
            {

                while (startingYield >= 100)
                {
                    yieldLeft += startingYield - 26;
                    startingYield -= dailyCost;
                    daysCount += 1;
                }

                BigInteger additionlConsume = 26;
                yieldLeft -= additionlConsume;
                Console.WriteLine(daysCount);
                Console.WriteLine(yieldLeft);

            }
        }
    }
}
