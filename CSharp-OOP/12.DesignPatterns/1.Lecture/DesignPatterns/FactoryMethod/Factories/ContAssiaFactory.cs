using FactoryMethod.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Factories
{
    public class ContAssiaFactory : IAnimalFactory
    {
        public IAnimal GetAnimal()
        {
            return new Mouse("Mousee", 18, "Assia");
        }
    }
}
