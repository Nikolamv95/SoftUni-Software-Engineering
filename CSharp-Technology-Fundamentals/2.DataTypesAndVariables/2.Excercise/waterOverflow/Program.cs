using System;

namespace waterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int waterCapacity = 255;

            while (nLines > 0)
            {
                int waterToAdd = int.Parse(Console.ReadLine());

                if (waterCapacity > waterToAdd)
                {
                    waterCapacity -= waterToAdd;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(waterCapacity);
        }
    }
}
