using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProjectExample.ValidationAttributes;
using WebProjectExample.ViewModels.Recipes;

namespace WebProjectExample.ViewModels.NewRecipes
{
    public enum NewTypeFood
    {
        FastFood = 1,
        LongTimeFood = 2,
    }

    public class AddNewRecipeInputModel
    {
        [MinLength(5)]
        [RegularExpression("[a-zA-Z]+")]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FirstCooked { get; set; }
        public NewTypeFood Type { get; set; }

        [Range(1900, int.MaxValue)]
        [CurrentYearMaxValueAttribute(1900)]
        public int Year { get; set; }
        public NewRecipeTImeInputModel Time { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}
