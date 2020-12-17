using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            //Calculations
            double volume = length * width * height;
            double volumeCmToLiters = volume * 0.001;
            double percentageToNumber = percentage * 0.01;
            double freeSpace = volumeCmToLiters * (1-percentageToNumber);

            //Output
            Console.WriteLine($"{freeSpace:f2}");
        }
    }
}
