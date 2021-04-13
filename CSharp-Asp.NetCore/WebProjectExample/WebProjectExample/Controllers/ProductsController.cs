using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebProjectExample.Models;

namespace WebProjectExample.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public Product Test()
        {
            return new Product()
            {
                ActiveFrom = DateTime.UtcNow,
                Description = "Description",
                Name = "name",
                Price = 123.34
            };
        }

        [HttpDelete]
        public string SoftUni()
        {
            return "DELETE!";
        }

        //We can receive the id with query in the url ?key=value or
        [HttpPost("{id}")] // and it will be receive if the opened url is /api/products/value(number)
        //[HttpPost]

        //Always return ActionResult<of object> in order to unlock the full functionalities of the method.
        public ActionResult<IEnumerable<Product>> AddProduct(Product product, int id)
        {
            //if we want to  throw an exception
            if (id % 2 == 0)
            {
                return NotFound();
            }

            product.Id = id;
            return new List<Product> { product , product , product , product };
        }
    }
}
