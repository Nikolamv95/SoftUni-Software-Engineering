using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WebProjectExample.Data;
using WebProjectExample.Models;
using WebProjectExample.Services;
using WebProjectExample.ViewModels.Home;

namespace WebProjectExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IShortStringService shortStringService;
        private readonly IConfiguration configuration;
        private readonly IInstanceCounter instanceCounter;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, IShortStringService shortStringService, IConfiguration configuration, IInstanceCounter instanceCounter)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.shortStringService = shortStringService;
            this.configuration = configuration;
            this.instanceCounter = instanceCounter;
        }
        //After the ActionViewFilter we enter in to the real view
        public IActionResult Index(int id)
        {
            //These 2 types of injection data into the view is very bad

            //Inject data into the VIew with ViewData
            //Dictionary<string, dynamic>
            //          or
            //Dictionary<string, object>
            this.ViewData["Year"] = 2021;
            this.ViewData["Name"] = "Nikola";
            this.ViewData["UsersCount"] = this.dbContext.Users.Count();

            //Inject data into the VIew with ViewBag
            //dynamic
            this.ViewBag.Name = "Nikola";
            this.ViewBag.Year = 2021;
            this.ViewBag.UsersCount = this.dbContext.Users.Count();

            //Inject data into the VIew with ViewModel
            var viewModel = new IndexViewModel();

            viewModel.Id = id;//we take the id from the routing syntax in start up class
            viewModel.Name = "Nikola";
            viewModel.Year = DateTime.UtcNow.Year;
            viewModel.ProcessorCount = Environment.ProcessorCount;
            viewModel.UsersCount = this.dbContext.Users.Count();
            viewModel.Description = "str.Length <=maxLengthddddddddddddssssaweqdsawe";

            viewModel.Description = this.shortStringService.GetShort(viewModel.Description, 10);


            //Read session
            viewModel.ReadSession = this.HttpContext.Session.Keys.Contains("ReadSession");
            return View(viewModel);
        }

        public IActionResult Privacy(int year, int month, int date)
        {
            //our custom route will fill the data int the variables year, month, date

            //On this address Home/Privacy we will open the Index View
            //return View("Index", new IndexViewModel());
            return View();

            //we can tell him to open view in different folder
            //return View("(special symbol check in the presentation)/Views/Shared/Error.cshtml");

        }

        public IActionResult NewIndex(int id)
        {
            var viewModel = new IndexViewModel();

            viewModel.Id = id;//we take the id from the routing syntax in start up class
            viewModel.Name = "Nikola";
            viewModel.Year = DateTime.UtcNow.Year;
            viewModel.ProcessorCount = Environment.ProcessorCount;
            viewModel.UsersCount = this.dbContext.Users.Count();
            viewModel.Description = "str.Length <=maxLengthddddddddddddssssaweqdsawe";

            viewModel.Description = this.shortStringService.GetShort(viewModel.Description, 10);

            return View(viewModel);
        }

        //Work WEB.API JSON Format
        public IActionResult AjaxDemo()
        {
            return this.View();
        }

        [ResponseCache(Duration = 24 * 60 * 60)]
        public IActionResult AjaxDemoData()
        {
            return this.Json(new[]
            {
                new {Name = "Nikola", Date = DateTime.UtcNow.ToString("O")},
                new {Name = "Stoqn", Date = DateTime.UtcNow.AddDays(1).ToString("O")},
                new {Name = "Pesho", Date = DateTime.UtcNow.AddDays(2).ToString("O")}
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StatusCodeError(int errorCode)
        {
            //this is how we control which error page to show
            if (errorCode == 404)
            {
                return this.View();
            }
            else
            {
                return this.Redirect("Error");
            }
        }

        public IActionResult ReadSession()
        {
            this.HttpContext.Session.SetString("ReadSession", "true");
            return this.View();
        }
    }
}
