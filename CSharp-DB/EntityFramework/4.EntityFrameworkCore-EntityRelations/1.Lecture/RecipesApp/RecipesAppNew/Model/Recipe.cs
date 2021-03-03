using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipesApp.Model
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Descriptiom { get; set; }

        // ? Allowes type of data which are not nullable to be nullable
        public TimeSpan? CookingTime { get; set; }
    }
}
