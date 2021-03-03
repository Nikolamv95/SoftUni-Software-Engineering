using System.Collections.Generic;

namespace NewRecipeSystem.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
