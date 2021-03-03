using System;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //We can read information from Person
            var persontype = typeof(Person);
            persontype.GetProperty("Ivan");
            Console.WriteLine(persontype.Name);
        }
    }
}
