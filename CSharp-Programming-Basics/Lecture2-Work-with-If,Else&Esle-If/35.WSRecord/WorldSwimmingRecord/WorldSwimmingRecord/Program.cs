using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSec = double.Parse(Console.ReadLine());
            double distanceMet = double.Parse(Console.ReadLine());
            double swim1metter = double.Parse(Console.ReadLine());

            double swim = distanceMet * swim1metter;
            double slow = Math.Floor(distanceMet / 15) * 12.5;
            double fullTime = swim + slow;

            if (fullTime < recordSec)
            {
                 Console.WriteLine($"Yes, he succeeded! The new world record is {fullTime:f2} seconds.");
            }
            else
            {
                double final = fullTime - recordSec;
                Console.WriteLine($"No, he failed! He was {final:f2} seconds slower.");
            }
        }
    }
}
