using SimpleFactory.Factory;
using SimpleFactory.Model;
using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;
            var factory = new AnimalFactory();
            animal = factory.CreateAnimal("Dog", "Doggy", 18);
            Console.WriteLine(animal.GetType().Name);//Returns object Dog
        }
    }
}
