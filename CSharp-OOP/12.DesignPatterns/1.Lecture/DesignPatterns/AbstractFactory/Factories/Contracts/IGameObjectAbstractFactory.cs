using AbstractFactory.Models.Animals.Contracts;
using AbstractFactory.Models.Humans.Contracts;

namespace AbstractFactory.Factories
{
    public interface IGameObjectAbstractFactory
    {
        IAnimal CreateAnimal();
        IHero CreateHuman();
    }
}