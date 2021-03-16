using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;

namespace ProductShop
{
    using System;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());
            GetUsersWithProducts(context);
        }

        //!!Exercise 1 -> Create ProductShop DB
        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        //Exercise 2 -> Import Users
        public static void ImportUsers(ProductShopContext context)
        {
            string xmlUserAsXMLString = File.ReadAllText("../../../Datasets/users.xml");
            string xmlRootAttributeUser = "Users";

            ImportUserDto[] userDtos = XmlConverter
                .Deserializer<ImportUserDto>(xmlUserAsXMLString, xmlRootAttributeUser);

            User[] realUsers = userDtos
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToArray();

            context.Users.AddRange(realUsers);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realUsers.Length}");
        }

        // Exercise 3 -> Import Products
        public static void ImportProducts(ProductShopContext context)
        {
            string xmlProductsAsXMLString = File.ReadAllText("../../../Datasets/products.xml");
            string xmlRootAttributeProd = "Products";

            ImportProductDto[] productsDtos = XmlConverter
                .Deserializer<ImportProductDto>(xmlProductsAsXMLString, xmlRootAttributeProd);

            var realProducts = productsDtos
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                })
                .ToArray();

            context.Products.AddRange(realProducts);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realProducts.Length}");
        }

        //Exercise 4 -> Import Categories
        public static void ImportCategories(ProductShopContext context)
        {
            string xmlCategoriesAsXMLString = File.ReadAllText("../../../Datasets/categories.xml");
            string xmlRootAttribute = "Categories";

            ImportCategoryDto[] categoriesDtos = XmlConverter
                .Deserializer<ImportCategoryDto>(xmlCategoriesAsXMLString, xmlRootAttribute);

            Category[] realCategories = categoriesDtos
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToArray();

            context.Categories.AddRange(realCategories);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realCategories.Length}");
        }

        //Exercise 5 -> Import Category Products
        public static void ImportCategoryProducts(ProductShopContext context)
        {
            string xmlCategProductAsXMLString = File.ReadAllText("../../../Datasets/categories-products.xml");
            string rootElement = "CategoryProducts";

            ImportCategoryProductDto[] categoryProductDtos = XmlConverter
                .Deserializer<ImportCategoryProductDto>(xmlCategProductAsXMLString, rootElement);

            List<CategoryProduct> realCategoryProduct = new List<CategoryProduct>();

            foreach (var categoryProduct in categoryProductDtos)
            {
                var categoryId = categoryProduct.CategoryId;
                var productId = categoryProduct.ProductId;

                bool isCategoryIdExist = context.Categories.Any(x => x.Id == categoryId);
                bool isProductIdExist = context.Products.Any(x => x.Id == productId);

                if (isCategoryIdExist && isProductIdExist)
                {
                    var realCatProd = new CategoryProduct()
                    {
                        ProductId = productId,
                        CategoryId = categoryId
                    };

                    realCategoryProduct.Add(realCatProd);
                }
            }

            context.CategoryProducts.AddRange(realCategoryProduct);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realCategoryProduct.Count}");
        }

        //Exercise 6 -> Products In Range
        public static void GetProductsInRange(ProductShopContext context)
        {
            const string xmlRootAttribute = "Products";

            var productDtos = context.Products
                .Where(x => x.Price >= 500 && x.Price < 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ExportGetProductsInRangeDto()
                {
                    ProductName = x.Name,
                    Price = x.Price,
                    FullName = x.Buyer.FirstName + " " + x.Buyer.LastName
                }).ToArray();

            var result = XmlConverter.Serialize(productDtos, xmlRootAttribute);

            Console.WriteLine(result);
        }

        //Excercise 7 -> Sold Products
        public static void GetSoldProducts(ProductShopContext context)
        {
            const string xmlRootAttribute = "Users";

            var userDtos = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.LastName)
                .Select(x => new ExportUserSoldProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProductsList = x.ProductsSold.Select(z => new UserProductDto()
                    {
                        Name = z.Name,
                        Price = z.Price
                    }).ToList()
                })
                .Take(5)
                .ToList();

            var result = XmlConverter.Serialize(userDtos, xmlRootAttribute);
            Console.WriteLine(result);
        }

        //Exercise 8 -> Products Count
        public static void GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string xmlRootAttribute = "Categories";

            var categoryDtos = context.Categories.Select(x => new ExportCategoryProductCountDto()
            {
                Name = x.Name,
                Count = x.CategoryProducts.Count(),
                AveragePrice = x.CategoryProducts.Average(z => z.Product.Price),
                TotalRevenue = x.CategoryProducts.Sum(z => z.Product.Price)
            })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categoryDtos, xmlRootAttribute);
            Console.WriteLine(result);

        }

        public static void GetUsersWithProducts(ProductShopContext context)
        {
            const string xmlRootAttributeMain = "Users";

            var userSoldInfoDtos = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderByDescending(x => x.ProductsSold.Count())
                .Select(x => new UserWithProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProductsList = new SoldProductDto
                    {
                        Count = x.ProductsSold.Count(),
                        ProductsList = x.ProductsSold.Select(p=> new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .OrderByDescending(z=>z.Price)
                            .ToList()
                    }
                })
                .Take(10)
                .ToList();

            var userAndProduct = new UserAndProductsDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = userSoldInfoDtos
            };

            var result = XmlConverter.Serialize(userAndProduct, xmlRootAttributeMain);
            Console.WriteLine(result);

        }
    }
}


