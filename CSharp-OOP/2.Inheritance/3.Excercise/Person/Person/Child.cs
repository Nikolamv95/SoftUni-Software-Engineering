using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age 
        {
            get 
            {
                return base.Age;
            }
            set 
            {
                if (Age > 15 )
                {
                    throw new ArgumentException("Age could not be be greater than 15");
                }
                else
                {
                    base.Age = value;
                }
            } 
        }
    }
}
