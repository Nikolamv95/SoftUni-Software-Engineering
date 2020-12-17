using System;

namespace _16.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inptu
            int campaignDays = int.Parse(Console.ReadLine());
            int confectionerNumbers = int.Parse(Console.ReadLine());
            int cakeNumbers = int.Parse(Console.ReadLine());
            int wafflesNumbers = int.Parse(Console.ReadLine());
            int pancakeNumbers = int.Parse(Console.ReadLine());
            //ConstantNumbers
            double cake = 45;
            double waffle = 5.80;
            double pancake = 3.20;
            //Calculations
            double cakePrice = cakeNumbers * cake;
            double wafflesPrice = wafflesNumbers * waffle;
            double pancakePrice = pancakeNumbers * pancake;

            double charitySumDays = ((cakePrice + wafflesPrice + pancakePrice) * confectionerNumbers);
            double charitySumAll = charitySumDays * campaignDays;
            double charityExpenses = charitySumAll / 8;
            double charityFunds = charitySumAll - charityExpenses;

            //Formated cut the numbers after the second number after the dot
            Console.WriteLine($"{charityFunds:f2}");
            //Round the number after the second number of the variable
            Console.WriteLine($"{Math.Round(charityFunds, 1)}");


        }
    }
}
