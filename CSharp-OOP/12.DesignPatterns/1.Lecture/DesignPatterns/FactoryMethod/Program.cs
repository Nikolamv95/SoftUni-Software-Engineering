using FactoryMethod.Factories;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which continent you wanna play?");
            
            string continent = Console.ReadLine();

            IAnimalFactory factory = null;

            if (continent == "Europe")
            {
                factory = new ContEuropeFactory();
            }
            else if (continent =="Asia")
            {
                factory = new ContAssiaFactory();
            }
            else if (continent == "Affrica")
            {
                factory = new ContAffricaFactory();
            }

            IAnimal animal = factory.GetAnimal();
            Console.WriteLine(animal.GetType().Name);
        }
    }
}
