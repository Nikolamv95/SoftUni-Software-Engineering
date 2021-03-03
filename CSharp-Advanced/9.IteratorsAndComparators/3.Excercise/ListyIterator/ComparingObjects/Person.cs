using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person()
        {

        }

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person personToCheck)
        {
            if (this.name.CompareTo(personToCheck.name) == 0)
            {
                if (this.age.CompareTo(personToCheck.age) == 0)
                {
                    if (this.town.CompareTo(personToCheck.town) == 0)
                    {
                        return  0;
                    }
                }
            }

            return -1;
        }
    }
}
