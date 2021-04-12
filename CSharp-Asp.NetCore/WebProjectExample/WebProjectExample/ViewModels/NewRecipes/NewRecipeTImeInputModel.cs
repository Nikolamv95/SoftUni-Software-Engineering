using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectExample.ViewModels.NewRecipes
{
    public class NewRecipeTImeInputModel : IValidatableObject
    {
        [Range(1, 24 * 60)]
        public int CookingTime { get; set; }

        [Range(1, 2 * 24 * 60)]
        public int PreparationTime { get; set; }


        //This is a global data validation for whole data class
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PreparationTime > this.CookingTime)
            {
                yield return new ValidationResult("Prep. time cannot be more than cooking time!");
            }

            if (this.PreparationTime + this.CookingTime > 2.5 * 24 * 60)
            {
                yield return new ValidationResult("Prep. time plus cooking time cannot be more than 2 and a half days!");
            }
        }
    }
}
