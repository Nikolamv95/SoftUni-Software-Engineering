using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfKozunak = int.Parse(Console.ReadLine());
            List<double> sumOfFlour = new List<double>();
            List<double> sumOfSugar = new List<double>();
            

            for (int i = 0; i < numOfKozunak; i++)
            {
                double usedSugar = double.Parse(Console.ReadLine());
                double usedFlour = double.Parse(Console.ReadLine());

                sumOfSugar.Add(usedSugar);
                sumOfFlour.Add(usedFlour);
            }

            double totalFlour = sumOfFlour.Sum();
            double totalSugar = sumOfSugar.Sum();

            int neededFlourPacks = (int)Math.Ceiling(totalFlour / 750);
            int neededSugarPacks = (int)Math.Ceiling(totalSugar / 950);

            Console.WriteLine($"Sugar: {neededSugarPacks}");
            Console.WriteLine($"Flour: {neededFlourPacks}");

            double maxFlour = sumOfFlour.Max();
            double maxSugar = sumOfSugar.Max();

            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
