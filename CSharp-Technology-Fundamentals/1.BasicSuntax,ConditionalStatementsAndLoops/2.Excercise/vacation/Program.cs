using System;
using System.Diagnostics;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine().ToLower();
            string dayOfTheWeek = Console.ReadLine().ToLower();

            double pricePerPerson = 0;

            switch (typeOfPeople)
            {
                case "students":
                    if (dayOfTheWeek == "friday")
                    {
                        pricePerPerson = 8.45;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        pricePerPerson = 9.80;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        pricePerPerson = 10.46;
                    }
                    break;

                case "business":
                    if (dayOfTheWeek == "friday")
                    {
                        pricePerPerson = 10.90;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        pricePerPerson = 15.60;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        pricePerPerson = 16;
                    }
                    break;

                case "regular":
                    if (dayOfTheWeek == "friday")
                    {
                        pricePerPerson = 15;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        pricePerPerson = 20;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        pricePerPerson = 22.50;
                    }
                    break;
            }

            double totalPrice = 0;

            if (typeOfPeople == "students" && numberOfPeople >= 30)
            {
                totalPrice = (pricePerPerson * numberOfPeople) * 0.85;
            }
            else if (typeOfPeople == "business" && numberOfPeople >= 100)
            {
                numberOfPeople -= 10;
                totalPrice = pricePerPerson * numberOfPeople;
            }
            else if (typeOfPeople == "regular" && numberOfPeople >= 10 && numberOfPeople <= 20)
            {
                totalPrice = (pricePerPerson * numberOfPeople) * 0.95;
            }
            else
            {
               totalPrice = pricePerPerson * numberOfPeople;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
