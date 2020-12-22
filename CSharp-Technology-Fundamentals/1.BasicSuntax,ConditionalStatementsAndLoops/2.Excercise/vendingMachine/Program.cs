using System;

namespace vendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            string coins = Console.ReadLine();
            double sumCoins = 0;

            while (coins != "Start")
            {
                double coinsDoub = Convert.ToDouble(coins);

                switch (coinsDoub)
                {
                    case 2:
                    case 1:
                    case 0.5:
                    case 0.2:
                    case 0.1:
                        sumCoins += coinsDoub;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coinsDoub}");
                        break;
                }

                coins = Console.ReadLine();
            }
            while (coins == "Start")
            {
                string order = Console.ReadLine().ToLower();

                double nuts = 2.00;
                double water = 0.70;
                double crisps = 1.50;
                double soda = 0.80;
                double coke = 1.00;
                double moneyLeft = 0;

                if (order == "end")
                {
                    Console.WriteLine($"Change: {sumCoins:F2}");
                    break;
                }
                else if (order == "nuts" && sumCoins >= nuts)
                {
                    sumCoins -= nuts;
                    Console.WriteLine($"Purchased {order}");
                }
                else if (order == "water" && sumCoins >= water)
                {
                    sumCoins -= water;
                    Console.WriteLine($"Purchased {order}");
                }
                else if (order == "crisps" && sumCoins >= crisps)
                {
                    sumCoins -= crisps;
                    Console.WriteLine($"Purchased {order}");
                }
                else if (order == "soda" && sumCoins >= soda)
                {
                    sumCoins -= soda;
                    Console.WriteLine($"Purchased {order}");
                }
                else if (order == "coke" && sumCoins >= coke)
                {
                    sumCoins -= coke;
                    Console.WriteLine($"Purchased {order}");
                }
                else
                {
                    if (order != "nuts" || order != "water" ||
                        order != "crisps" || order != "soda" ||
                                                 order != "coke")
                    {

                        Console.WriteLine("Invalid product");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
            }
        }

    }
}
