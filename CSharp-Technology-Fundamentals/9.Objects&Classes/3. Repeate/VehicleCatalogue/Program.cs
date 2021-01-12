using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue_Excercise
{
    class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {

            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Vehicle> listOfVehicle = new List<Vehicle>();

            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = data[0];
                string model = data[1];
                string color = data[2];
                double horsePower = double.Parse(data[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                listOfVehicle.Add(vehicle);
            }

            string vehiclePrint = string.Empty;

            while ((vehiclePrint = Console.ReadLine()) != "Close the Catalogue")
            {
                var filteredList = listOfVehicle.Where(x => x.Model == vehiclePrint);

                foreach (var item in filteredList)
                {
                    if (item.Type == "car")
                    {
                        Console.WriteLine($"Type: Car");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                    else
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
            }

            List<Vehicle> listOfCars = listOfVehicle.Where(x => x.Type == "car").ToList();
            List<Vehicle> listOfTrucks = listOfVehicle.Where(x => x.Type == "truck").ToList();

            double sumOfCars = listOfCars.Sum(x => x.HorsePower);
            double sumOfTrucks = listOfTrucks.Sum(x => x.HorsePower);

            double avgCarHp = 0.00;
            double avgTruckHp = 0.00;

            if (listOfCars.Count > 0)
            {
                avgCarHp = sumOfCars / listOfCars.Count;
            }
            if (listOfTrucks.Count > 0)
            {
                avgTruckHp = sumOfTrucks / listOfTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:f2}.");
        }

    }

}
