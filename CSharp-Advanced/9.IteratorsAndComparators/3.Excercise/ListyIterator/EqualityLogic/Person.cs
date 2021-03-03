using System;

namespace EqualityLogic
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person()
        {

        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person personToCheck)
        {
            if (this.name.CompareTo(personToCheck.name) != 0)
            {
                return this.name.CompareTo(personToCheck.name);
            }

            if (this.age.CompareTo(personToCheck.age) != 0)
            {
                return this.age.CompareTo(personToCheck.age);
            }

            return 0;
        }
        //За да направих HashSeta да има същата функционалност като SortedSet
        //трябва да създадем override метод GetHashCode който събира хашстойността на името + хашстойността на годините
        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode();
        }
        //и ги сравнява с оverride метода Equals дали този текущата стойност от хашстойността се равнява на друга такава
        //която вече е записана в HashSeta, ако е така връща true и не се записва обекта, защото вече има такъв
        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            return false;
        }
    }
}
