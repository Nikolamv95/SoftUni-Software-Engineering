using System;
using System.Collections.Generic;
using System.Text;

namespace CreateInstance
{
    public abstract class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
