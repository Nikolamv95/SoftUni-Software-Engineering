using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.Members = new List<Person>();
        }
        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            int minValue = int.MinValue;
            Person oldestPerson = new Person();

            foreach (var item in this.Members)
            {
                if (item.Age > minValue)
                {
                    minValue = item.Age;
                    oldestPerson = item;
                }
            }

            return oldestPerson;
        }
    }
}
