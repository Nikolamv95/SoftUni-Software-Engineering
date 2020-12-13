using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetFilm = double.Parse(Console.ReadLine());
            double numberPeople = double.Parse(Console.ReadLine());
            double chloatePerPerson = double.Parse(Console.ReadLine());

            double decoration = budgetFilm * 0.10;
            double fullPriceChloates = numberPeople * chloatePerPerson;

            if (numberPeople > 150)
            {
                fullPriceChloates *= 0.90;
            }

            double fullPrice = decoration + fullPriceChloates;

            if (fullPrice > budgetFilm)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {fullPrice - budgetFilm:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetFilm - fullPrice:f2} leva left.");
            }
        }
    }
}
