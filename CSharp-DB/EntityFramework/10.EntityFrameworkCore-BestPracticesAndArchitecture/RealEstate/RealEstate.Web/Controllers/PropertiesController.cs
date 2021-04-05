using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Services;

namespace RealEstate.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public IActionResult AddProperty()
        {
            return View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var properties = this.propertiesService.SearchBuyPrice(minPrice, maxPrice);
            return this.View(properties);
        }

        public IActionResult ShowAddedProperty(string district, int size, int? year, 
                                            int price, string propertyType, string buildingType, 
                                            int? floor, int? maxFloors)
        {
            this.propertiesService.Create(district, size,  year,
                 price,  propertyType,  buildingType,
                floor,  maxFloors);

            var property = this.propertiesService.GetExactProperty(district, size, year, price, propertyType, floor);
            return this.View(property);
        }
    }
}
