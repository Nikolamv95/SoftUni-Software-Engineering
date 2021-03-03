namespace FactoryMethod.Model
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, int age, string continent)
        {
            this.Name = name;
            this.Age = age;
            this.Continent = continent;
        }

        public string Name { get; private set;  }
        public int Age { get; private set; }

        public string Continent { get; private set; }
    }
}
