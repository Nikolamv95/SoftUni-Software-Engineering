using AbstractFactory.Factories;
using AbstractFactory.Model;
using AbstractFactory.Models.Animals.Contracts;
using AbstractFactory.Models.Humans.Contracts;

namespace FactoryMethod.Factories
{
    public class ContEuropeFactory : IGameObjectAbstractFactory
    {
        public IAnimal CreateAnimal()
        {
            return new Cat("Catyy", 18, "Europe");
        }

        public IHero CreateHuman()
        {
            return new Magician("Magic", 18, "Europe");
        }

    }
}
