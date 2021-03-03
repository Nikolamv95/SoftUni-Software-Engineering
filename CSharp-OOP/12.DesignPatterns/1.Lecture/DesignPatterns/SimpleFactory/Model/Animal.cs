namespace SimpleFactory.Model
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set;  }
        public int Age { get; private set; }
    }
}
