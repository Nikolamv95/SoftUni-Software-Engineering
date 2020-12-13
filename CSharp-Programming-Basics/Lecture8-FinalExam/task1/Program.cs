using System;

namespace task1V1
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerVideoCard = int.Parse(Console.ReadLine());
            int pricePerProvider = int.Parse(Console.ReadLine());
            double priceElectricityCard = double.Parse(Console.ReadLine());
            double profitPerCard = double.Parse(Console.ReadLine());

            double totalPriceCards = pricePerVideoCard * 13;
            double totalPriceProvider = pricePerProvider * 13;
            double totalSpendMoney = totalPriceCards + totalPriceProvider + 1000;
            double profitPerCardDaily = profitPerCard - priceElectricityCard;
            double dailyCardProfit = 13 * profitPerCardDaily;
            double returnInvest = totalSpendMoney / dailyCardProfit;

            Console.WriteLine(totalSpendMoney);
            Console.WriteLine($"{Math.Ceiling(returnInvest)}");
        }
    }
}
