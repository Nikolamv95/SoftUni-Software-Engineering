using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjectExample.ViewModels.NewRecipes;

namespace WebProjectExample.Controllers
{
    public class NewRecipesController : Controller
    {
        public IActionResult Add(AddNewRecipeInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Json(this.ModelState);
            }

            return this.Json(inputModel);
        }
    }
}
