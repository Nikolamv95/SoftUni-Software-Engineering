using System;

namespace newHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int numberFlower = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double finalPrice = 0;
            double discount = 0;

            double rosesPrice = 5;
            double dahliasPrice = 3.80;
            double tulipsPrice = 2.80;
            double narcissusPrice = 3;
            double gladiolusPrice = 2.50;

            switch (typeFlower)
            {
                case "Roses":
                    finalPrice = numberFlower * rosesPrice;
                    if (numberFlower > 80)
                    {
                        finalPrice *= 0.90;
                    }
                    break;
                case "Dahlias":
                    finalPrice = numberFlower * dahliasPrice;
                    if (numberFlower > 90)
                    {
                        finalPrice *= 0.85;
                    }
                    break;
                case "Tulips":
                    finalPrice = numberFlower * tulipsPrice;
                    if (numberFlower > 80)
                    {
                        finalPrice *= 0.85;
                    }
                    break;
                case "Narcissus":
                    finalPrice = numberFlower * narcissusPrice;
                    if (numberFlower < 120)
                    {
                        finalPrice *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    finalPrice = numberFlower * gladiolusPrice;
                    if (numberFlower < 80)
                    {
                        finalPrice *= 1.20;
                    }
                    break;
            }
            if (budget < finalPrice)
            {

                Console.WriteLine($"Not enough money, you need {finalPrice - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {numberFlower} {typeFlower} and {budget - finalPrice:f2} leva left.");
            }
        }
    }
}
