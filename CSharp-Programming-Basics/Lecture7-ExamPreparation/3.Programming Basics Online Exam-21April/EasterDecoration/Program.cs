using System;

namespace EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfClients = int.Parse(Console.ReadLine());

            double basketPrice = 1.50;
            double wreathPrice = 3.80;
            double chocolatePrice = 7.00;
            double totalBill = 0;

            string input;

            for (int i = 0; i < numOfClients; i++)
            {
                int currNumOfOrders = 0;
                double currTotalBill = 0;

                while ((input = Console.ReadLine()) != "Finish")
                {
                    currNumOfOrders += 1;

                    switch (input)
                    {
                        case "basket":
                            currTotalBill += basketPrice;
                            break;
                        case "wreath":
                            currTotalBill += wreathPrice;
                            break;
                        case "chocolate bunny":
                            currTotalBill += chocolatePrice;
                            break;
                    }
                }

                if (currNumOfOrders % 2 == 0)
                {
                    currTotalBill *= 0.80;
                }

                Console.WriteLine($"You purchased {currNumOfOrders} items for {currTotalBill:f2} leva.");
                totalBill += currTotalBill;
            }

            Console.WriteLine($"Average bill per client is: {totalBill / numOfClients:f2} leva.");
        }
    }
}
