using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Web.Models;
using System.Diagnostics;
using RealEstates.Services;

namespace RealEstate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictsService districtsService;

        public HomeController(IDistrictsService districtsService, IPropertiesService propertiesService)
        {
            this.districtsService = districtsService;
        }

        public IActionResult Index()
        {
            var districs = this.districtsService.GetTopDistrictsByAveragePrice(1000); 
            return View(districs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
