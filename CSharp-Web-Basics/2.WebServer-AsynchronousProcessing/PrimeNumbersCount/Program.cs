using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersCount
{
    class Program
    {
        private static int Count = 0;

        //We use the new object as na objects who will be locked by the threads and when thread-X is inside the locked object next thread will continue 
        //with the same object but with the updated data inside. Check locked object down bellow!
        private static object lockObj = new object();
        static void Main(string[] args)
        {
            /*
             * 00:00:08.7172378
             * 665026
             */

            Stopwatch sw = Stopwatch.StartNew();

            //We take the exceptions inside the thread!!!
            Thread thread = new Thread(() =>
            {
                try
                {
                    PrintPrimeCount(1, 2_500_000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            });
            thread.Start();

            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();

            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();

            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();

            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(Count);
        }

        static void PrintPrimeCount(int min, int max)
        {
            for (int i = min; i < max; i++)
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

                if (isPrime)//Locked object
                {
                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            }
        }
    }
}
