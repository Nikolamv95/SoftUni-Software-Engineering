using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAppNew.Model
{
    public class Address
    {
        public Address()
        {
            // we do that to initialize the ICollection
            this.Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string StreetLine1 { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
    

