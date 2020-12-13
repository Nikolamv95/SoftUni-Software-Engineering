using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int boughtFoodKg = int.Parse(Console.ReadLine());
            int boughtFoodGr = boughtFoodKg * 1000;

            string input = string.Empty;
            int eatenFood = 0;

            while ((input = Console.ReadLine()) != "Adopted")
            {
                int foodToEat = int.Parse(input);
                eatenFood += foodToEat;
            }

            if (eatenFood <= boughtFoodGr)
            {
                Console.WriteLine($"Food is enough! Leftovers: {boughtFoodGr - eatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {eatenFood - boughtFoodGr} grams more.");
            }

        }
    }
}
