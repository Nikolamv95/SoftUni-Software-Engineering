using System;

namespace touristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double expenses = 0;
            int numberProduct = 0;
            int totalNumberProducts = 0;
            bool exit = false;

            while (exit == false)
            {
                string productName = Console.ReadLine();

                while (productName != "Stop")
                {
                    double productPrice = double.Parse(Console.ReadLine());
                    totalNumberProducts += 1;
                    numberProduct += 1;

                    if (numberProduct == 3)
                    {
                        productPrice *= 0.50;

                        if (budget < productPrice)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Console.WriteLine($"You need {productPrice - budget:f2} leva!");
                            exit = true;
                            break;
                        }

                        numberProduct = 0;
                        expenses += productPrice;
                        budget = budget - productPrice;
                        break;
                    }
                    else
                    {
                        if (budget < productPrice)
                        {
                            Console.WriteLine("You don't have enough money!");
                            Console.WriteLine($"You need {productPrice - budget:f2} leva!");
                            exit = true;
                            break;
                        }

                        budget = budget - productPrice;
                        expenses += productPrice;
                        break;
                    }
                }

                if (productName == "Stop")
                {
                    Console.WriteLine($"You bought {totalNumberProducts} products for {expenses:f2} leva.");
                    break;
                }
                else if (exit == true)
                {
                    break;
                }
            }
        }
    }
}
