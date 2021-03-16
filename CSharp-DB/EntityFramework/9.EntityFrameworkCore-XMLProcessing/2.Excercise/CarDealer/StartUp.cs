using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using ProductShop.XmlHelper;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

        }

        //!!Exercise 1 -> Create ProductShop DB
        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        public static void ImportSuppliers(CarDealerContext context)
        {
            string xmlFileAsXMLString = File.ReadAllText("../../../Datasets/suppliers.xml");
            string RootAttribute = "Suppliers";

            var supplierDtos = XmlConverter.Deserializer<ImportSupplierDto>(xmlFileAsXMLString, RootAttribute);

            var realSupplier = supplierDtos.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            }).ToArray();

            context.Suppliers.AddRange(realSupplier);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realSupplier.Length}");
        }

        public static void ImportParts(CarDealerContext context)
        {
            string xmlFileAsXMLString = File.ReadAllText("../../../Datasets/parts.xml");
            string RootAttribute = "Parts";

            var partsDtos = XmlConverter.Deserializer<ImportPartDto>(xmlFileAsXMLString, RootAttribute);

            var realParts = partsDtos
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId))
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                }).ToArray();


            context.Parts.AddRange(realParts);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realParts.Length}");
        }

        public static void ImportCars(CarDealerContext context)
        {
            string xmlFileAsXMLString = File.ReadAllText("../../../Datasets/cars.xml");
            string RootAttribute = "Cars";

            ImportCarDto[] carDtos = XmlConverter.Deserializer<ImportCarDto>(xmlFileAsXMLString, RootAttribute);
            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var uniqueParts = carDto.Parts.Select(s => s.Id).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar()
                    {
                        PartId = id
                    }).ToList()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
            Console.WriteLine($"Successfully imported {carDtos.Length}");

        }

        public static void ImportCustomers(CarDealerContext context)
        {
            string xmlFileAsXMLString = File.ReadAllText("../../../Datasets/customers.xml");
            string RootAttribute = "Customers";

            var customerDtos = XmlConverter.Deserializer<ImportCustomerDto>(xmlFileAsXMLString, RootAttribute);

            var realCustomers = customerDtos.Select(c => new Customer()
            {
                Name = c.Name,
                BirthDate = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            }).ToArray();

            context.Customers.AddRange(realCustomers);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {realCustomers.Length}");
        }

        private static void ImportSales(CarDealerContext context)
        {
            string xmlFileAsXMLString = File.ReadAllText("../../../Datasets/sales.xml");
            string RootAttribute = "Sales";

            var saleDtos = XmlConverter.Deserializer<ImportSaleDto>(xmlFileAsXMLString, RootAttribute);
            List<Sale> allSales = new List<Sale>();

            foreach (var sale in saleDtos)
            {
                var currSale = new Sale
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };

                if (context.Cars.Any(x => x.Id == currSale.CarId))
                {
                    allSales.Add(currSale);
                }
            }

            context.Sales.AddRange(allSales);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {allSales.Count}");
        }
    }

}