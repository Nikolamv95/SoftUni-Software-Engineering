using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjectExample.ViewModels.Recipes;

namespace WebProjectExample.Controllers
{
    public class RecipesController : Controller
    {

        public IActionResult AddNew(int id, string name, string description, DateTime firstCooked)
        {
            return this.Json(new { id, name, description, firstCooked });
        }

        public IActionResult Add(AddRecipeInputModel recipeInputModel)
        {
            return this.Json(recipeInputModel);
        }

        public IActionResult AddUserAgent(
            [FromHeader ( Name = "User-Agent")] string userAgent, 
            AddRecipeInputModel recipeInputModel)
        {
            //we can ask different data from the httpRequest
           string cookie = this.HttpContext.Request.Cookies[".AspNet.Consent"];

            return this.Json(cookie);
        }

        //[FromForm] attribute will be taken only from the form table in the view
        public IActionResult AddFromForm([FromForm]AddRecipeInputModel recipeInputModel)
        {
            return this.Json(recipeInputModel);
        }

        //[Bind("Ingredients, Name")] will bind only those 2 properties
        public IActionResult AddBind([Bind("Ingredients, Name")] AddRecipeInputModel recipeInputModel)
        {
            return this.Json(recipeInputModel);
        }
    }
}
