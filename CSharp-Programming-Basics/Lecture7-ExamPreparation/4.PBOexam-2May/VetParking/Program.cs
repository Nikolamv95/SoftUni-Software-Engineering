using System;

namespace VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 1; i <= numOfDays; i++)
            {
                double taxPerHour = 0;

                for (int j = 1; j <= hoursPerDay; j++)
                {
                    if ((i % 2 == 0) && (j % 2 != 0))
                    {
                        taxPerHour += 2.50;
                    }
                    else if ((i % 2 != 0) && (j % 2 == 0))
                    {
                        taxPerHour += 1.25;
                    }
                    else
                    {
                        taxPerHour += 1;
                    }
                }

                Console.WriteLine($"Day: {i} – {taxPerHour:f2} leva");
                totalSum += taxPerHour;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
