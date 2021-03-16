using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //!!Exercise 1 -> Create ProductShop DB
            ResetDatabase(context);

            //!!Exercise 2 -> Import Suppliers
            string supplierJson = File.ReadAllText("../../../Datasets/suppliers.json");
            string resultSuplier = ImportSuppliers(context, supplierJson);
            Console.WriteLine(resultSuplier);

            //!!Exercise 3 -> Import Parts
            string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            string resultParts = ImportParts(context, partsJson);
            Console.WriteLine(resultParts);

            //!!Exercise 4 -> Import Car and PartCart with DTO -> IMPORTANT
            string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            string resultCars = ImportCars(context, carsJson);
            Console.WriteLine(resultCars);

            //!!Exercise 5 -> Import Customers
            string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            string resultCustomers = ImportCustomers(context, customersJson);
            Console.WriteLine(resultCustomers);

            //!!Exercise 6 -> Import Sales
            string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            string resultSales = ImportSales(context, salesJson);
            Console.WriteLine(resultSales);
        }

        //Import queries
        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            //Create DTO to read the json file
            var carDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            //Create lists in which you will store the Car and partCar objects
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            //With foreach read the DTO in which we store the data from JSON file
            foreach (var carDTO in carDtos)
            {
                //Create object car with it`s properties
                var newCar = new Car()
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance
                };
                //Store the object in to the list of cars
                cars.Add(newCar);

                //Create object partCars with it`s properties
                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    var newPartCar = new PartCar
                    {
                        PartId = partId,
                        Car = newCar
                    };

                    //Store the object in to the list of partCars
                    carParts.Add(newPartCar);
                }
            }

            //Add all cars in to the DB
            context.Cars.AddRange(cars);

            //Add all partCars in to the DB
            context.PartCars.AddRange(carParts);

            //Save changes in the context
            context.SaveChanges();

            //Return the result
            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}