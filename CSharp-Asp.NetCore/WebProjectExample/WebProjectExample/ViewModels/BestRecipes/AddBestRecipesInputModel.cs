using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebProjectExample.ValidationAttributes;
using WebProjectExample.ViewModels.NewRecipes;

namespace WebProjectExample.ViewModels.BestRecipes
{
    public enum NewTypeFood
    {
        [Display(Name = "Fast Food")]
        FastFood = 1,

        [Display(Name = "Long Time Food")]
        LongTimeFood = 2,

        [Display(Name = "Unknown")]  
        Unknown = 3,
    }

    public class AddBestRecipesInputModel
    {
        [MinLength(5)]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name should be only with letters. Minimum letters 5.")]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "First time the recipe is cooked")]
        public DateTime FirstCooked { get; set; }
        public NewTypeFood Type { get; set; }

        [Range(1900, int.MaxValue)]
        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }
        public NewRecipeTImeInputModel Time { get; set; }
        public IFormFile Image { get; set; }

        //If we want to upload multiple images use IEnumerable<IFormFile>
        public IEnumerable<IFormFile> MultipleImages { get; set; }
    }
}
