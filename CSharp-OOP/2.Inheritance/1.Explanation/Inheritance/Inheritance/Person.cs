using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Sleep()
        {
            Console.WriteLine("Sleeping");
        }

        public void Eat()
        {
            Console.WriteLine("He is eating");
        }
    }
}
