using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptiom { get; set; }
        public TimeSpan CookingTime { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
