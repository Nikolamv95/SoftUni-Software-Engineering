using System;

namespace GodzillavsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetMovie = double.Parse(Console.ReadLine());
            double peopleNumber = double.Parse(Console.ReadLine());
            double clothesPricePerPeople = double.Parse(Console.ReadLine());
            
            double finalChlotesPrice = 0.0;
            double decorMovie = budgetMovie * 0.1;


            if (peopleNumber > 150)
            {
                double discount = (peopleNumber * clothesPricePerPeople) * 0.1;
                finalChlotesPrice = (peopleNumber * clothesPricePerPeople) - discount;
            }
            else
            {
                finalChlotesPrice = peopleNumber * clothesPricePerPeople;
            }

            double finalBudget = finalChlotesPrice + decorMovie;

            if (finalBudget > budgetMovie)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {finalBudget - budgetMovie:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetMovie - finalBudget:f2} leva left.");
            }

        }
    }
}
