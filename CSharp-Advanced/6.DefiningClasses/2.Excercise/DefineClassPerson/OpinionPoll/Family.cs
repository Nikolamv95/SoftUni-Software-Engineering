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

        public List<Person> GetMembersOver30()
        {
            List<Person> listOfPersons = new List<Person>();
            listOfPersons = this.Members.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            return listOfPersons;
        }
    }
}
