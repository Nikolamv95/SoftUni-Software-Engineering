using System;

namespace summerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int gradus = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            string shoes ="";
            string outfit = "";

            if (10 <= gradus && gradus <= 18)
            {
                if (day == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (day == "Afternoon" || day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (18 < gradus && gradus <= 24)
            {
                if (day == "Morning" || day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (day == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (gradus >= 25)
            {
                if (day == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (day == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {gradus} degrees, get your {outfit} and {shoes}."); 
        }
    }
}
