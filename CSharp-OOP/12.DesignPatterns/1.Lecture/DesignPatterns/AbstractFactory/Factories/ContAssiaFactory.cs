using AbstractFactory.Factories;
using AbstractFactory.Model;
using AbstractFactory.Models.Animals.Contracts;
using AbstractFactory.Models.Humans.Contracts;

namespace FactoryMethod.Factories
{
    public class ContAssiaFactory : IGameObjectAbstractFactory
    {
        public IAnimal CreateAnimal()
        {
            return new Mouse("Mousee", 18, "Assia");
        }

        public IHero CreateHuman()
        {
            return new Warrior("Warriorar", 18, "Assia");
        }
    }
}
