using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesAppNew.Model.one_to_many_new
{
    public class Employee
    {
        public int Id { get; set; }

        //These properties have conenction with 
        //public ICollection<Employee> Workers { get; set; } from town
        public int? BirthTownId { get; set; }
        public Town BirthTown { get; set; }

        //These properties have conenction with 
        //public ICollection<Employee> Citizens { get; set; }
        public int? WorkTownId { get; set; }
        public Town WorkTown { get; set; }
    }
}
