using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionConstructors
{
    public class Person
    {
        private string name;

        public Person(string name, string gender)
        {
            this.Name = name;
            this.Gender = name;
        }

        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
