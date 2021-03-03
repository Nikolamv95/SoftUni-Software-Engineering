using System;

namespace ReflectionConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is how we set a constructor with array
            var personConstructor = typeof(Person).GetConstructor(new Type[] { typeof(string) });
            var person = personConstructor.Invoke(new object[]{ "Marin", "Man"}) as Person;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Gender);
        }
    }
}
