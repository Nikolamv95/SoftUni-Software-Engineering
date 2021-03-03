
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipesAppNew.Model.one_to_many_new
{
    public class Town
    {
        public int Id { get; set; }
        public int Name { get; set; }

        [InverseProperty("WorkTown")]
        public ICollection<Employee> Workers { get; set; }

        [InverseProperty("BirthTown")]
        public ICollection<Employee> Citizens { get; set; }
    }
}
