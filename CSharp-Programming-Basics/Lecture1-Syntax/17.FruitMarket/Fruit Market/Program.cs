using System;

namespace Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double berryPrice = double.Parse(Console.ReadLine());
            double bananaKg = double.Parse(Console.ReadLine());
            double orangeKg = double.Parse(Console.ReadLine());
            double raspberriesKg = double.Parse(Console.ReadLine());
            double berryKg = double.Parse(Console.ReadLine());

            //Calculations Price per Product per kg
            double raspberriesPrice = berryPrice * 0.50;
            double orangePrice = raspberriesPrice * 0.60;
            double bananaPrice = raspberriesPrice * 0.20;

            //Calculations Price product * needed kg
            double raspberriesFullPrice = raspberriesPrice * raspberriesKg;
            double orangeFullPrice = orangePrice * orangeKg;
            double bananaFullPrice = bananaPrice * bananaKg;
            double berriesFullPrice = berryPrice * berryKg;

            //Calculations FullPrice
            double allProductsFullPrice = (raspberriesFullPrice + orangeFullPrice + bananaFullPrice + berriesFullPrice);

            //Output
            Console.WriteLine($"{allProductsFullPrice:f2}");         

        }
    }
}