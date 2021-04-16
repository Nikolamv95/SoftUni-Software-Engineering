using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebProjectExample.ViewModels.BestRecipes;
using WebProjectExample.ViewModels.NewRecipes;
using NewTypeFood = WebProjectExample.ViewModels.BestRecipes.NewTypeFood;

namespace WebProjectExample.Controllers
{
    public class BestRecipesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public BestRecipesController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Add()
        {
            //Its good practice to show the form with random data, just to present how
            //it should be filled by the client

            var model = new AddBestRecipesInputModel()
            {
                Type = NewTypeFood.Unknown,
                FirstCooked = DateTime.UtcNow,
                Time = new NewRecipeTImeInputModel()
                {
                    CookingTime = 10,
                    PreparationTime = 5,
                }
            };

            return this.View(model);
        }

        //When something is async do the while method Task<IActionResult> and the methods bellow await
        [HttpPost]
        public async Task<IActionResult> Add(AddBestRecipesInputModel input)
        {

            if (!input.Image.FileName.EndsWith(".png"))
            {
                //This row will write the error in the ModelState and the view
                this.ModelState.AddModelError("Image", "Invalid file type");
            }

            if (input.Image.Length > 10*1024*1024)
            {
                this.ModelState.AddModelError("Image", "File is too big. Maximum 20 mb allowed.");
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            //If we work with only one image
            await using (var fs = new FileStream(this.webHostEnvironment.WebRootPath + "/user.png", FileMode.Create))
            {
                await input.Image.CopyToAsync(fs);
            }



            //TODO: Save data from service

            // input.Image.ContentType -> NEVER USE CONTENT TYPE to check what is the content of the file which you received. PROTECTION!!!
            //USE ImageSharp nuget pack to validate what is the type of the file which you received. Check only the name input.Image.Name


            //Redirect to action is preferred action to use if you what to redirect the user. It can be dynamically.
            //Both have same function but in the Redirect you have to hardcore the full path to the action /"controller"/"action"
            return this.RedirectToAction(nameof(ThankYou));
            //return this.Redirect("/Recipes/ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        //This method returns the file which we saved in our wwwroot folder
        public IActionResult Image()
        {
            return this.PhysicalFile(this.webHostEnvironment.WebRootPath + "/images/user.png", "image/png");
        }

        public IActionResult HighCharts()
        {
            return this.View();
        }
    }
}
