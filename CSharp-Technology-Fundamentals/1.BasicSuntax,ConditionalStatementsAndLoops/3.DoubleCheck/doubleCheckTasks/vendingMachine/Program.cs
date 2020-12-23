using System;

namespace vendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string insertCoins = Console.ReadLine();
            double money = 0;

            while (insertCoins != "Start" )
            {
                switch (insertCoins)
                {
                    case "2":
                        money += 2;
                        break;
                    case "1":
                        money += 1;
                        break;
                    case "0.5":
                        money += 0.5;
                        break;
                    case "0.2":
                        money += 0.2;
                        break;
                    case "0.1":
                        money += 0.1;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {insertCoins}");
                        break;
                }
                insertCoins = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {

                switch (product)
                {
                    case "Nuts":

                        if (money >= 2.00)
                        {
                            money -= 2.00;
                            Console.WriteLine($"Purchased nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (money >= 0.70)
                        {
                            money -= 0.70;
                            Console.WriteLine($"Purchased water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (money >= 1.50)
                        {
                            money -= 1.50;
                            Console.WriteLine($"Purchased crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (money >= 0.80)
                        {
                            money -= 0.80;
                            Console.WriteLine($"Purchased soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (money >= 1.0)
                        {
                            money -= 1.00;
                            Console.WriteLine($"Purchased coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
