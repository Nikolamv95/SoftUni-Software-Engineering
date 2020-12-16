using System;

namespace SmallShopV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double peaces = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":

                    switch (product)
                    {
                        case "coffee":
                            Console.WriteLine($"{peaces * 0.50}");
                            break;

                        case "water":
                            Console.WriteLine($"{peaces * 0.90}");
                            break;

                        case "beer":
                            Console.WriteLine($"{peaces * 1.20}");
                            break;

                        case "sweets":
                            Console.WriteLine($"{peaces * 1.45}");
                            break;

                        case "peanuts":
                            Console.WriteLine($"{peaces * 1.60}");
                            break;

                    }
            } 
        }
    }
}
