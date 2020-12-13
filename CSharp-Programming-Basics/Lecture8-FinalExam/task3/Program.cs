using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int timeSpend = int.Parse(Console.ReadLine());
            int numOfPeople = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double pricePerHour = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (dayOrNight == "day")
                    {
                        pricePerHour = 10.50;
                    }
                    else
                    {
                        pricePerHour = 8.40;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (dayOrNight == "day")
                    {
                        pricePerHour = 12.60;
                    }
                    else
                    {
                        pricePerHour = 10.20;
                    }
                    break;
            }

            if (numOfPeople >= 4)
            {
                pricePerHour *= 0.90;
            }
            if (timeSpend >= 5)
            {
                pricePerHour *= 0.50;
            }

            double totalPrice = (pricePerHour * numOfPeople) * timeSpend;

            Console.WriteLine($"Price per person for one hour: {pricePerHour:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
