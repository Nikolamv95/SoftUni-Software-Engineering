using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class Snake : Animal
    {
        public override void Eat(object food)
        {
            if (!(food is StartUp))
            {
                Console.WriteLine("Eat = Snake");
            }
        }
    }
}
