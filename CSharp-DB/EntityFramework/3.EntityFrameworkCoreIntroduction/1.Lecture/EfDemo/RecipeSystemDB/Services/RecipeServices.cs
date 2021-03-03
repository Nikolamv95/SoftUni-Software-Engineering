using NewRecipeSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipesSystem.Services
{
    public class RecipeServices
    {
        private RecepiesDbContext db;

        public RecipeServices(RecepiesDbContext db)
        {
            this.db = new RecepiesDbContext();
        }

        public IList<Recipe> GetRecepies(List<string> recipes)
        {
            IList<Recipe> result = null;

            for (int i = 0; i < recipes.Count; i++)
            {
                string nameRecipe = recipes[i];
                var recipe = this.db.Recipes.FirstOrDefault(x => x.Name == nameRecipe);
                result.Add(recipe);
            }

            return result;
        }

        public Recipe GetRecepies(string recipeToReturn)
        {
            var recipe = this.db.Recipes.FirstOrDefault(x => x.Name == recipeToReturn);

            return recipe;
        }
    }
}
