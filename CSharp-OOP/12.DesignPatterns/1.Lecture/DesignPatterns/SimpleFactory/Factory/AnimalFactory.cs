using SimpleFactory.Model;

namespace SimpleFactory.Factory
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string typeAnimal, string name, int age)
        {
            IAnimal animal = null;

            if (typeAnimal == "Dog")
            {
                animal = new Dog(name, age);
            }
            else if (typeAnimal == "Cat")
            {
                animal = new Cat(name, age);
            }
            else if (typeAnimal == "Mouse")
            {
                animal = new Mouse(name, age);
            }

            return animal;
        }
    }
}
