using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectExample.ViewModels.BestRecipes
{
    public class BestRecipeTimeInputModel
    {
        [Range(1, 24 * 60)]
        public int CookingTime { get; set; }

        [Range(1, 2 * 24 * 60)]
        public int PreparationTime { get; set; }
    }
}
