using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebProjectExample.ModelBinders;

namespace WebProjectExample.ViewModels.Recipes
{

    public enum TypeFood
    {
        FastFood = 1,
        LongTimeFood = 2,
    }

    public class AddRecipeInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FirstCooked { get; set; }
        public TypeFood Type { get; set; }

        //[ModelBinder(typeof(ExtractYearModelBinder))]
        public int Year { get; set; }
        public RecipeTimeInputModel Time { get; set; }
        public IEnumerable<string> Ingredients { get; set; }

        //public string[] Ingredients { get; set; }
    }
}
