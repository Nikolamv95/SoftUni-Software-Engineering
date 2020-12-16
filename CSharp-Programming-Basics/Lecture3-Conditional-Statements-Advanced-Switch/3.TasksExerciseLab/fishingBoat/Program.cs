using System;

namespace fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            int fishermans = int.Parse(Console.ReadLine());

            
            double price = 0;
            double totalPrice = 0;

            switch (season)
            {
                case "spring":
                    price = 3000;
                    if (fishermans <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (fishermans >= 7 && fishermans <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermans >= 12)
                    {
                        price *= 0.75;
                    }
                    break;

                case "summer":
                case "autumn":
                    price = 4200;
                    if (fishermans <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (fishermans >= 7 && fishermans <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermans >= 12)
                    {
                        price *= 0.75;
                    }
                    break;

                case "winter":
                    price = 2600;
                    if (fishermans <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (fishermans >= 7 && fishermans <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermans >= 12)
                    {
                        price *= 0.75;
                    }
                    break;
            }

            if (season != "autumn")
            {
                 
                if (fishermans % 2 == 0)
                {
                    price *= 0.95;
                }
            }

            if (price <= budget)
            {
                totalPrice = budget - price;
                Console.WriteLine($"Yes! You have {totalPrice:f2} leva left.");
            }
            else
            {
                totalPrice = price - budget;
                Console.WriteLine($"Not enough money! You need {totalPrice:f2} leva.");
            }
        }
    }
}
