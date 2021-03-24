using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersParallel
{
    class Program
    {
        private static int Count = 0;
        private static object lockObj = new object();

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            PrintPrimeCount(1, 10_000_000);
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(Count);
        }

        static void PrintPrimeCount(int min, int max)
        {
            Parallel.For(min, max + 1, i =>
            {
                bool isPrime = true;

                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            });
        }
    }
}
