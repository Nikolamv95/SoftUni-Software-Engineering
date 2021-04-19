using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProjectExample.Data;
using WebProjectExample.Models;

namespace WebProjectExample.Controllers
{
    // REST /api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await this.db.Products.AddAsync(product);
            await this.db.SaveChangesAsync();
            return this.CreatedAtAction("Get", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = this.db.Products.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }

            this.db.Remove(product);
            await this.db.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            this.db.Entry(product).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
            return this.NoContent();
        }

        ////We can receive the id with query in the url ?key=value or
        //[HttpPost("{id}")] // and it will be receive if the opened url is /api/products/value(number)
        ////[HttpPost]
        ////Always return ActionResult<of object> in order to unlock the full functionalities of the method.
        //public ActionResult<IEnumerable<Product>> AddProduct(Product product, int id)
        //{
        //    //if we want to  throw an exception
        //    if (id % 2 == 0)
        //    {
        //        return NotFound();
        //    }

        //    product.Id = id;
        //    return new List<Product> { product , product , product , product };
        //}
    }
}
