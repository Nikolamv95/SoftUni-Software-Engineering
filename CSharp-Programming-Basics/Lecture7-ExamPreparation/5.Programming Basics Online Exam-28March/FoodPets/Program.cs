using System;

namespace FoodPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());
            double totalEatenFood = int.Parse(Console.ReadLine());
            double totalFoodDoog = 0;
            double totalFoodCat = 0;
            double eatenBisquits = 0;

            for (int i = ; i <= numOfDays; i++)
            {
                double eatenFoodDog = double.Parse(Console.ReadLine());
                double eatenFoodCat = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    double eatenFoodDay = eatenFoodCat + eatenFoodDog;
                    eatenBisquits += eatenFoodDay - (eatenFoodDay * 0.90);
                    totalFoodDoog += eatenFoodDog;
                    totalFoodCat += eatenFoodCat;
                }
                else
                {
                    totalFoodDoog += eatenFoodDog;
                    totalFoodCat += eatenFoodCat;
                }

            }
            double totalCurrFood = totalFoodDoog + totalFoodCat;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(eatenBisquits)}gr.");
            Console.WriteLine($"{(totalCurrFood / totalEatenFood) * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(totalFoodDoog / totalCurrFood) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalFoodCat / totalCurrFood * 100:f2}% eaten from the cat.");
        }
    }
}
