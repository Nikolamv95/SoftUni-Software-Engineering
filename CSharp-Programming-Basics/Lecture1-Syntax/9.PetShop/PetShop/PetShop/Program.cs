using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDogs = int.Parse(Console.ReadLine());
            int numberPets = int.Parse(Console.ReadLine());
            double SumDogsFood = numberDogs * 2.5;
            int SumPetsFood = numberPets * 4;
            Console.WriteLine(SumDogsFood + SumPetsFood + " lv.");
        }
    }
}
