using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class Dog : Animal
    {
        public override void Eat(object food)
        {
            base.Eat(food);
        }

        public override void Sleep()
        {
            base.Sleep();
        }
    }
}
