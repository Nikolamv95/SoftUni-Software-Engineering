using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Serialization;

namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            //!!Exercise 1 -> Create ProductShop DB
            //ResetDatabase(context);

            //!!Exercise 2 -> Import Users
            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //string resultUsers = ImportUsers(context, usersJson);
            //Console.WriteLine(resultUsers);

            //!!Exercise 3 -> Import Products
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string resultProducts = ImportProducts(context, productsJson);
            //Console.WriteLine(resultProducts);

            //!!Exercise 4 -> Categories Products
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string resultCategories = ImportCategories(context, categoriesJson);
            //Console.WriteLine(resultCategories);

            //!!Exercise 5 -> Categories Products
            //string categoriesAndProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string resultCategoriesAndProducts = ImportCategAndProd(context, categoriesAndProductsJson);
            //Console.WriteLine(resultCategoriesAndProducts);

            //!!Exercise 6 -> Export Products in Range
            //string resultProductsRange = GetProductsInRange(context);
            //EnsureDirectoryExist(ResultDirectoryPath);
            //File.WriteAllText(ResultDirectoryPath + "/products-in-range.json", resultProductsRange);

            //string resultProductsRange = GetProductsInRangeWithDTO(context);
            //Console.WriteLine(resultProductsRange);

            //Exercise 7 -> Export Successfully Sold Products
            //string sellersResult1 = GetSoldProductsDTO(context);
            //string sellersResult2 = GetSoldProductsAutoMapper(context);
            //Console.WriteLine(sellersResult2);

            ////Exercise 8 -> Categories by Products Count
            //string categoryResult = GetCategoriesByProductsCount(context);
            //Console.WriteLine(categoryResult);

            //Exercise 9 -> Users and Products
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        private static void EnsureDirectoryExist(string resultDirectoryPath)
        {
            if (!Directory.Exists(resultDirectoryPath))
            {
                Directory.CreateDirectory(resultDirectoryPath);
            }
        }

        //Import queries
        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        private static string ImportProducts(ProductShopContext context, string productsJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(productsJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }

        private static string ImportCategories(ProductShopContext context, string categoriesJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(categoriesJson)
                .Where(x => x.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        private static string ImportCategAndProd(ProductShopContext context, string categoriesAndProductsJson)
        {
            CategoryProduct[] categoriesAndProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(categoriesAndProductsJson);
            context.CategoryProducts.AddRange(categoriesAndProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesAndProducts.Length}";
        }

        //Export queries
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price.ToString("f2"),
                    seller = (x.Seller.FirstName == null ? "" : x.Seller.FirstName) + " " + (x.Seller.LastName == null ? "" : x.Seller.LastName)
                })
                .OrderBy(x => x.price)
                .ToList();

            var result = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return result;
        }

        public static string GetProductsInRangeWithDTO(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ListProductInRange
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerName = (x.Seller.FirstName == null ? "" : x.Seller.FirstName) + " " + (x.Seller.LastName == null ? "" : x.Seller.LastName)
                })
                .OrderBy(x => x.Price)
                .ToList();

            var result = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(x => x.ProductsSold.Any(z => z.Buyer != null))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    LastName = x.LastName,
                    soldProduct = x.ProductsSold.Select(z => new
                    {
                        name = z.Name,
                        price = z.Price,
                        buyerFirstName = z.Buyer.FirstName,
                        buyerLastName = z.Buyer.LastName,
                    })
                })
                .ToList();

            var result = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            return result;
        }

        public static string GetSoldProductsDTO(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(x => x.ProductsSold.Any(z => z.Buyer != null))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(x => new UserWithSoldProductDTO()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ListSoldProducts = x.ProductsSold.Select(z => new UserProductSoldDTO()
                    {
                        ProductName = z.Name,
                        Price = z.Price,
                        BuyerFirstName = z.Buyer.FirstName,
                        BuyerLastName = z.Buyer.LastName,
                    })
                        .ToList()

                })
                .ToList();

            var result = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            return result;
        }
        public static string GetSoldProductsAutoMapper(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(x => x.ProductsSold.Any(z => z.Buyer != null))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ProjectTo<UserWithSoldProductDTO>()
                .ToList();

            var result = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryInfo = context.Categories
                .Select(x => new
                {
                    category = x.Name,

                    productsCount = x.CategoryProducts.Count,

                    averagePrice = x.CategoryProducts
                            .Average(z => z.Product.Price)
                            .ToString("f2"),

                    totalRevenue = x.CategoryProducts
                            .Sum(z => z.Product.Price)
                            .ToString("f2")

                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categoryInfo, Formatting.Indented);

            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                    }
                })
                .ToList();

            var result = new
            {
                UsersCount = users.Count,
                Users = users
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var usersJson = JsonConvert.SerializeObject(result, Formatting.Indented, settings);

            return usersJson;
        }
    }
}