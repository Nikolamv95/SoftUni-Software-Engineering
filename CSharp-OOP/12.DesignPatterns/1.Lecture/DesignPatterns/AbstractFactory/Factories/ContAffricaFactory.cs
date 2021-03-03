using AbstractFactory.Factories;
using AbstractFactory.Model;
using AbstractFactory.Models.Animals.Contracts;
using AbstractFactory.Models.Humans.Contracts;

namespace FactoryMethod.Factories
{
    public class ContAffricaFactory : IGameObjectAbstractFactory
    {
        public IAnimal CreateAnimal()
        {
            return new Dog("Doggy", 18, "Affrica");
        }

        public IHero CreateHuman()
        {
            return new Warrior("Warri", 18, "Affrica");
        }
    }
}
