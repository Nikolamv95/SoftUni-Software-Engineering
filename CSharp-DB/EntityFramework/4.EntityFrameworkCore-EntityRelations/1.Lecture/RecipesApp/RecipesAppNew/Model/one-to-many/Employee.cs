using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAppNew.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
