using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipesAppNew.Model.many_to_many
{
    public class Recipe
    {
        public Recipe()
        {
            // we do that to initialize the ICollection
            this.RecipeIngridients = new HashSet<RecipeIngridient>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Descriptiom { get; set; }

        public ICollection<RecipeIngridient> RecipeIngridients { get; set; }
    }
}
