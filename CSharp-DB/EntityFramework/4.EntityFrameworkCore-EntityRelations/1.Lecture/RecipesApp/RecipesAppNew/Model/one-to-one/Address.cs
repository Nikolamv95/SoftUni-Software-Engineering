using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipesAppNew.Model.one_to_one
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetLine1 { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
