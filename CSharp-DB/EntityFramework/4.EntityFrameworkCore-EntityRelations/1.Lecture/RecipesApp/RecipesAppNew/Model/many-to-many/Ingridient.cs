using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipesAppNew.Model.many_to_many
{
    public class Ingridient
    {
        public Ingridient()
        {
            // we do that to initialize the ICollection
            this.RecipeIngridients = new HashSet<RecipeIngridient>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }

        public ICollection<RecipeIngridient> RecipeIngridients { get; set; }
    }
}
