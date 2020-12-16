using System;

namespace hoelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApartment = 0;

            if (month == "May" || month == "October")
            {
                priceStudio = 50;
                priceApartment = 65;

                if (nights > 7 && nights <= 14)
                {
                    priceStudio *= 0.95;
                }
                else if (nights > 14)
                {
                    priceStudio *= 0.70;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;

                if (nights > 14)
                {
                    priceStudio *= 0.80;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = 76;
                priceApartment = 77;
            }

            if (nights > 14)
            {
                priceApartment *= 0.9;
            }

            double totalPriceApartment = priceApartment * nights;
            double totalPriceStudio = priceStudio * nights;


            Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");


        }
    }
}
