using System;

namespace _15.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intput
            double priceRent = double.Parse(Console.ReadLine());

            // Calculations
            double priceCake = priceRent * 0.20;
            double priceDrinks = priceCake * 0.55;
            double priceAnimator = priceRent / 3;
            double allPrice = priceCake + priceDrinks + priceAnimator + priceRent;

            //OutPut
            Console.WriteLine($"{allPrice:f2}");
        }
    }
}
