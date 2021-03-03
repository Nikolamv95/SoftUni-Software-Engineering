using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;

namespace WildFarm.Core.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string[] args)
        {
            Animal animal = null;

            if (args.Length == 1)
            {
                bool isBird = double.TryParse(args[0], out double wingSize);

                if (isBird)
                {
                    if (type == "Hen")
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                    else if (type == "Owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.INV_TYPE);
                    }
                }
                else
                {
                    string livingRegion = args[0];

                    if (type == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else if (type == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.INV_TYPE);
                    }
                }
                
            }
            else if (args.Length == 2)
            {
                string livingRegion = args[0];
                string breed = args[1];

                if (type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.INV_TYPE);
                }

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INV_TYPE);
            }

            return animal;

        }
    }
}
