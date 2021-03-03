namespace AbstractFactory.Models.Animals.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }
        public int Age { get; }
        public string Continent { get; }
    }
}

