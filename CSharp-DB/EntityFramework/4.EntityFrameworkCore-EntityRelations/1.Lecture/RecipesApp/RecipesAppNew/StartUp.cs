using RecipesApp.Model;
using RecipesAppNew.Model.many_to_many;
using System;

namespace RecipesAppNew
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //In one recipe we add ingredients trough the middle table
            var recipe = new Recipe
            {
                Name = "Musaka",
                CookingTime = new TimeSpan(2, 3, 4),
                Ingredients =
                {
                    new RecipeIngridient
                    {
                        Ingridient = new Ingridient { Name = "Patato"},
                        QuantityIngridient = 2000,
                    },
                    new RecipeIngridient
                    {
                        Ingridient = new Ingridient { Name = "Meat"},
                        QuantityIngridient = 1000,
                    }
                }
            };

            //context.save.changes
        }
    }
}
