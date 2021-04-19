using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjectExample.Controllers;
using WebProjectExample.Data;
using WebProjectExample.Models;
using Xunit;

namespace WebProjectExample.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetShouldReturnTheProductIfFound()
        {
            var product = new Product()
            {
                Id = 10,
                Name = "product test",
                Price = 100,
            };

            // This is virtual DB which we can use it the same way as the normal one
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDB");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var controller = new ProductsController(dbContext);

            var result = controller.Get(10);
            Assert.NotNull(result);
            Assert.Equal("product test", result.Value.Name);
        }

        [Fact]
        public void GetShouldReturnNotFountIfProductDoesNotExist()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDB");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var controller = new ProductsController(dbContext);
            
            //Act
            var result = controller.Get(3);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
