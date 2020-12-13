using System;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelLitters = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double fuelPrice = 2.10;
            double tripGuide = 100;
            double saturday = 0.90;
            double sunday = 0.80;
            double spendMoney = 0;

            fuelPrice = fuelPrice * fuelLitters;
            spendMoney = fuelPrice + tripGuide;

            if (dayOfWeek == "Saturday")
            {
                spendMoney = spendMoney * saturday;
            }
            else
            {
                spendMoney = spendMoney * sunday;
            }

            if (budget >= spendMoney)
            {
                budget = budget - spendMoney;
                Console.WriteLine($"Safari time! Money left: {budget:f2} lv.");
            }
            else
            {
                spendMoney = spendMoney - budget;
                Console.WriteLine($"Not enough money! Money needed: { spendMoney:f2} lv.");
            }
        }
    }
}
