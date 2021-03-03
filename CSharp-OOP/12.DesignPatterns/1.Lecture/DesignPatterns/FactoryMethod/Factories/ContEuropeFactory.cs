using FactoryMethod.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Factories
{
    public class ContEuropeFactory : IAnimalFactory
    {
        public IAnimal GetAnimal()
        {
            return new Cat("Catyy", 18, "Europe");
        }
    }
}
