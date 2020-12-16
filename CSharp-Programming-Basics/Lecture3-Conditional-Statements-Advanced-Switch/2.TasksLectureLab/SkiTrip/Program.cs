using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfStay = int.Parse(Console.ReadLine());
            string typeApartment = Console.ReadLine();
            string review = Console.ReadLine();

            double roomOnePerson = 18;
            double apartment = 25;
            double presiApartment = 35;

            int nights = daysOfStay - 1;
            double finalPrice = 0;

            //Room for one person
            if (typeApartment == "room for one person")
            {
                finalPrice = nights * roomOnePerson;
            }

            // Apartment
            else if (typeApartment == "apartment")
            {
                if (nights < 10)
                {
                    finalPrice = (nights * apartment);
                    finalPrice *= 0.70;
                }
                else if (nights <= 15)
                {
                    finalPrice = (nights * apartment);
                    finalPrice *= 0.65;
                }
                else if (nights > 15)
                {
                    finalPrice = (nights * apartment);
                    finalPrice *= 0.50;
                }
            }

            // Presidental Apartment
            else if (typeApartment == "president apartment")
            {
                if (nights < 10)
                {
                    finalPrice = nights * presiApartment;
                    finalPrice *= 0.90;
                }
                else if (nights <= 15)
                {
                    finalPrice = nights * presiApartment;
                    finalPrice *= 0.85;
                }
                else if (nights > 15)
                {
                    finalPrice = nights * presiApartment;
                    finalPrice *= 0.80;
                }
            }

            //Review Positive or Negative
            if (review == "positive")
            {
                finalPrice *= 1.25;
                Console.WriteLine($"{finalPrice:f2}");
            }
            else if (review == "negative")
            {
                finalPrice *= 0.90;
                Console.WriteLine($"{finalPrice:f2}");
            }

        }
    }
}
