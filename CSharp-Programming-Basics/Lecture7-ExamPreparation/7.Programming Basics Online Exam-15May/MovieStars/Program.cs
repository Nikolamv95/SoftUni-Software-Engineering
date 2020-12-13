using System;

namespace MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string nameOfActor = string.Empty;
            double moneySpend = 0;
            bool isNotEnough = false;

            while ((nameOfActor = Console.ReadLine()) != "ACTION")
            {
                if (nameOfActor.Length > 15)
                {
                    budget -= (budget * 0.20);
                }
                else
                {
                    double salary = double.Parse(Console.ReadLine());
                    budget -= salary;
                }

                if (budget < 0)
                {
                    Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
                    isNotEnough = true;
                    break;
                }
            }

            if (isNotEnough == false)
            {
                Console.WriteLine($"We are left with {budget:f2} leva.");
            }
        }
    }
}
