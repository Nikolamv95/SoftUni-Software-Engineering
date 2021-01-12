using System;
using System.Collections.Generic;
using System.Linq;

namespace vehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input =string.Empty;
            List<Catalogue> listOfVehicles = new List<Catalogue>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] dataFields = input
                                      .Split("/")
                                      .ToArray();

                string type = dataFields[0];
                string brand = dataFields[1];
                string model = dataFields[2];
                string horsePower = dataFields[3];
                string weight = dataFields[3];

                Catalogue vehicle = new Catalogue();

                vehicle.Type = type;
                vehicle.Brand = brand;
                vehicle.Model = model;
                vehicle.HorsePower = horsePower;
                vehicle.Weight = weight;

                listOfVehicles.Add(vehicle);
            }

            List<Catalogue> sortedList = listOfVehicles.OrderBy(x => x.Brand).ToList();

            int counter = 1;
            foreach (Catalogue vehicle in sortedList)
            {
                if (vehicle.Type == "Car")
                {
                    if (counter == 1)
                    {
                        Console.WriteLine("Cars:");
                        counter++;
                    }
                    
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
                }
            }

            int counter2 = 1;
            foreach (Catalogue vehicle in sortedList)
            {
                if (vehicle.Type == "Truck")
                {
                    if (counter2 == 1)
                    {
                        Console.WriteLine("Trucks:");
                        counter2++;
                    }
                    
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.Weight}kg");
                }
            }
        }

        class Catalogue
        {
            public string Type { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Weight { get; set; }
            public string HorsePower { get; set; }
        }
    }
}
