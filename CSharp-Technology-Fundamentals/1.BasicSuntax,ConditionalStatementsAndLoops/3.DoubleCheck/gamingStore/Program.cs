using System;

namespace gamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string gameToBuy = Console.ReadLine();
            double sum = 0;
            double firstMoney = money;

            while (gameToBuy != "Game Time")
            {
                //Games to buy
                switch (gameToBuy)
                {
                    case "OutFall 4":
                        double outfall = 39.99;
                        if (money >= outfall)
                        {
                            money -= outfall;
                            sum += outfall;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        double csgo = 15.99;
                        if (money >= csgo)
                        {
                            money -= csgo;
                            sum += csgo;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        double zzell = 19.99;
                        if (money >= zzell)
                        {
                            money -= zzell;
                            sum += zzell;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        double honored2 = 59.99;
                        if (money >= honored2)
                        {
                            money -= honored2;
                            sum += honored2;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        double roverW = 29.99;
                        if (money >= roverW)
                        {
                            money -= roverW;
                            sum += roverW;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        double roverWOrg = 39.99;
                        if (money >= roverWOrg)
                        {
                            money -= roverWOrg;
                            sum += roverWOrg;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                    gameToBuy = Console.ReadLine();
            }

            if (money == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                firstMoney -= sum;
                Console.WriteLine($"Total spent: ${sum:f2}. Remaining: ${firstMoney:f2}");
            }
        }
    }
}
