using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionGetMethod
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string GetName()
        {
            return this.Name;
        }
    }
}
