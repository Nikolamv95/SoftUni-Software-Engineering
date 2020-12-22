using System;

namespace gamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double outfall4 = 39.99;
            double csGo = 15.99;
            double zplinterZell = 19.99;
            double honored2 = 59.99;
            double roverWatch = 29.99;
            double roverWatchOrg = 39.99;
            double totalSpent = 0;
            

            string gameToBuy = Console.ReadLine();

            while (gameToBuy != "Game Time")
            {
                if (budget > 0)
                {
                    switch (gameToBuy)
                    {
                        case "OutFall 4":
                            if (budget >= outfall4)
                            {
                                budget -= outfall4;
                                totalSpent += outfall4;
                                Console.WriteLine($"Bought {gameToBuy}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "CS: OG":
                            if (budget >= csGo)
                            {
                                budget -= csGo;
                                totalSpent += csGo;
                                Console.WriteLine($"Bought {gameToBuy}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Zplinter Zell":
                            if (budget >= zplinterZell)
                            {
                                budget -= zplinterZell;
                                totalSpent += zplinterZell;
                                Console.WriteLine($"Bought {gameToBuy}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Honored 2":
                            if (budget >= honored2)
                            {
                                budget -= honored2;
                                totalSpent += honored2;
                                Console.WriteLine($"Bought {gameToBuy}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch":
                            if (budget >= roverWatch)
                            {
                                budget -= roverWatch;
                                totalSpent += roverWatch;
                                Console.WriteLine($"Bought {gameToBuy}");
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch Origins Edition":
                            if (budget >= roverWatchOrg)
                            {
                                budget -= roverWatchOrg;
                                totalSpent += roverWatchOrg;
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
                }
                else
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                gameToBuy = Console.ReadLine();
            }
            if (budget == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${budget:f2}");
            }

            
        }
    }
}
