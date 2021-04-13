using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using WebProjectExample.Data;
using WebProjectExample.Models;

namespace WebProjectExample.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NewProductsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public NewProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.db.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

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
            return this.CreatedAtAction("Get", new {id = product.Id}, product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            this.db.Entry(product).State = EntityState.Modified;
            await this.db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteProduct(int id)
        {
            var product = this.db.Products.FirstOrDefault(x=> x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            this.db.Products.Remove(product);
            await this.db.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
