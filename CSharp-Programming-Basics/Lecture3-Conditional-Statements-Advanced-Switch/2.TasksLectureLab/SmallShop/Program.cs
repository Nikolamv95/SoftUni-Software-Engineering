using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double peaces = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    double price = peaces * 0.50;
                    Console.WriteLine($"{price}");
                }
                else if (product == "water")
                {
                    double price = peaces * 0.80;
                    Console.WriteLine($"{price}");
                }
                else if (product == "beer")
                {
                    double price = peaces * 1.20;
                    Console.WriteLine($"{price}");
                }
                else if (product == "sweets")
                {
                    double price = peaces * 1.45;
                    Console.WriteLine($"{price}");
                }
                else if (product == "peanuts")
                {
                    double price = peaces * 1.60;
                    Console.WriteLine($"{price}");
                }
            }

            else if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    double price = peaces * 0.40;
                    Console.WriteLine($"{price}");
                }
                else if (product == "water")
                {
                    double price = peaces * 0.70;
                    Console.WriteLine($"{price}");
                }
                else if (product == "beer")
                {
                    double price = peaces * 1.15;
                    Console.WriteLine($"{price}");
                }
                else if (product == "sweets")
                {
                    double price = peaces * 1.30;
                    Console.WriteLine($"{price}");
                }
                else if (product == "peanuts")
                {
                    double price = peaces * 1.50;
                    Console.WriteLine($"{price}");
                }
            }

            else if (city == "Varna")
            {
                if (product == "coffee")
                {
                    double price = peaces * 0.45;
                    Console.WriteLine($"{price}");
                }
                else if (product == "water")
                {
                    double price = peaces * 0.70;
                    Console.WriteLine($"{price}");
                }
                else if (product == "beer")
                {
                    double price = peaces * 1.10;
                    Console.WriteLine($"{price}");
                }
                else if (product == "sweets")
                {
                    double price = peaces * 1.35;
                    Console.WriteLine($"{price}");
                }
                else if (product == "peanuts")
                {
                    double price = peaces * 1.55;
                    Console.WriteLine($"{price}");
                }
            }
        }
    }
}
