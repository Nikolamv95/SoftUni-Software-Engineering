using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var dbContext = new RealEstateDbContext();
            dbContext.Database.Migrate();

            IPropertiesService propertiesService = new PropertyService(dbContext);
            IDistrictsService districtsService = new DistrictsService(dbContext);

            Console.Write("Min Price:.....");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Max Price:.....");
            int maxPrice = int.Parse(Console.ReadLine());

            var properties = propertiesService.SearchBuyPrice(minPrice, maxPrice);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District}, {property.Price:f2}€," +
                                      $" fl. {property.Floor}, {property.Size} m2," +
                                      $" {property.PropertyType}, {property.BuildingType}");
            }

            Console.WriteLine(new string('-',60));

            var disitricts = districtsService.GetTopDistrictsByAveragePrice();
            foreach (var district in disitricts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePrice:f2}" +
                                  $" => {district.MaxPrice:f2} => {district.MinPrice:f2} " +
                                  $"=> {district.PropertiesCount} properties");
            }
        }
    }
}
