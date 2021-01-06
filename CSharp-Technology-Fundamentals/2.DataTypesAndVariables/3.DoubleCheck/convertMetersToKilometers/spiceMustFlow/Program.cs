using System;
using System.Numerics;

namespace spiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger yieldStart = BigInteger.Parse(Console.ReadLine());
            BigInteger yieldLeft = yieldStart;
            BigInteger noYield = 0; 
            BigInteger daysCouns = 0;
            
            if (yieldStart < 100)
            {
                Console.WriteLine(daysCouns);
                Console.WriteLine(noYield);
            }
            else
            {
                while (yieldStart >= 100)
                {
                    daysCouns += 1;

                    if (daysCouns > 1)
                    {
                        yieldLeft += yieldStart;
                    }
                    yieldLeft = yieldLeft - 26;
                    yieldStart -= 10;
                }

                yieldLeft -= 26;
                Console.WriteLine(daysCouns);
                Console.WriteLine(yieldLeft);
            }
        }
    }
}
