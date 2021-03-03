using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class Animal
    {
        public virtual void Eat(object food)
        {
            Console.WriteLine("I`m Animal - eating the food" + food);
        }

        public virtual void Sleep()
        {
            Console.WriteLine("I`m sleeping - Animal");
        }
    }
}
