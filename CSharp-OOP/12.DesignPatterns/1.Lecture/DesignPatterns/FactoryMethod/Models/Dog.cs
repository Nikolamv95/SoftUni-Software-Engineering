namespace FactoryMethod.Model
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string continent)
            : base(name, age, continent)
        {
        }
    }
}
