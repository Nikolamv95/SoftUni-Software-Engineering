using AbstractFactory.Factories;
using AbstractFactory.Models.Animals.Contracts;
using AbstractFactory.Models.Humans.Contracts;
using FactoryMethod.Factories;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type your continent to create objects");
            string continent = Console.ReadLine();

            IGameObjectAbstractFactory factory = null;

            if (continent == "Europe")
            {
                factory = new ContEuropeFactory();
            }
            else if (continent == "Asia")
            {
                factory = new ContAssiaFactory();
            }
            else if (continent == "Affrica")
            {
                factory = new ContAffricaFactory();
            }

            IAnimal animal = factory.CreateAnimal();
            IHero human = factory.CreateHuman();

            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine(human.GetType().Name);
        }
    }
}
