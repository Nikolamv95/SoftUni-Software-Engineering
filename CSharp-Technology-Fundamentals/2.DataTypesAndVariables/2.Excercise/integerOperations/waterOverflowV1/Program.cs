using System;

namespace waterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int waterCapacity = 255;
            int sumWater = 0;

            while (nLines > 0)
            {
                int waterToAdd = int.Parse(Console.ReadLine());

                if (waterCapacity >= waterToAdd)
                {
                    waterCapacity -= waterToAdd;
                    sumWater += waterToAdd;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                nLines -= 1;
            }
            Console.WriteLine(sumWater);
        }
    }
}
