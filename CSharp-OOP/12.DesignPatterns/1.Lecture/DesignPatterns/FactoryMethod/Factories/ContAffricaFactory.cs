using FactoryMethod.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Factories
{
    public class ContAffricaFactory : IAnimalFactory
    {
        public IAnimal GetAnimal()
        {
            return new Dog("Doggy", 18, "Affrica");
        }
    }
}
