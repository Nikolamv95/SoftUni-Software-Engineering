using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string destinastion1 = "Bulgaria";
            string destinastion2 = "Balkans";
            string destinastion3 = "Europe";

            string place = "Camp";
            string place2 = "Hotel";

            double moneySpend = 0;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    moneySpend = budget * 0.30;
                    Console.WriteLine($"Somewhere in {destinastion1}");
                    Console.WriteLine($"{place} - {moneySpend:f2}");
                }
                else if (season == "winter")
                {
                    moneySpend = budget * 0.70;
                    Console.WriteLine($"Somewhere in {destinastion1}");
                    Console.WriteLine($"{place2} - {moneySpend:f2}");
                }
            }

            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    moneySpend = budget * 0.40;
                    Console.WriteLine($"Somewhere in {destinastion2}");
                    Console.WriteLine($"{place} - {moneySpend:f2}");
                }
                else if (season == "winter")
                {
                    moneySpend = budget * 0.80;
                    Console.WriteLine($"Somewhere in {destinastion2}");
                    Console.WriteLine($"{place2} - {moneySpend:f2}");
                }
            }

            else if (budget > 1000)
            {
                moneySpend = budget * 0.90;
                Console.WriteLine($"Somewhere in {destinastion3}");
                Console.WriteLine($"{place2} - {moneySpend:f2}");
            }
        }
    }
}
