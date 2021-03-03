using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp.Model
{
    public class Ingredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe  Recipe { get; set; }

    }
}
