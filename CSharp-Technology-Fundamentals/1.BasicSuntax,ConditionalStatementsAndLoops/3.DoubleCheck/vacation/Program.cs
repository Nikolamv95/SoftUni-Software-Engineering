using System;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine().ToLower();
            string dayOfTheWeek = Console.ReadLine().ToLower();
            double price = 0;

            switch (typeOfPeople)
            {
                case "students":
                    if (dayOfTheWeek == "friday")
                    {
                        price = 8.45;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        price = 9.80;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        price = 10.46;
                    }

                    // calculations
                    if (numberPeople >= 30)
                    {
                        price = (numberPeople * price) * 0.85;
                    }
                    else
                    {
                        price = numberPeople * price;
                    }
                    break;

                case "business":
                    if (dayOfTheWeek == "friday")
                    {
                        price = 10.90;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        price = 15.60;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        price = 16;
                    }

                    // calculations
                    if (numberPeople >= 100)
                    {
                        price = (numberPeople - 10) * price;
                    }
                    else
                    {
                        price = numberPeople * price;
                    }
                    break;
                case "regular":
                    if (dayOfTheWeek == "friday")
                    {
                        price = 15;
                    }
                    else if (dayOfTheWeek == "saturday")
                    {
                        price = 20;
                    }
                    else if (dayOfTheWeek == "sunday")
                    {
                        price = 22.50;
                    }

                    // calculations
                    if (numberPeople >= 10 && numberPeople <= 20)
                    {
                        price = (numberPeople * price) * 0.95;
                    }
                    else
                    {
                        price = numberPeople * price;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
