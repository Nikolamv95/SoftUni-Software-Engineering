using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("RealEstateData.json");
            var properties = JsonSerializer.Deserialize<IEnumerable<JsonProperty>>(json);

            var dbContext = new RealEstateDbContext();
            IPropertiesService propertiesService = new PropertyService(dbContext);

            foreach (var property in properties.Where(x => x.Price > 1000))
            {
                try
                {
                    propertiesService.Create(
                        property.District,
                        property.Size,
                        property.Year,
                        property.Price,
                        property.Type,
                        property.BuildingType,
                        property.Floor,
                        property.TotalFloors);
                }
                catch
                {
                }
            }
        }
    }
}
