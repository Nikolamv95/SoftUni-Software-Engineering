using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public partial class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;
            List<Tire[]> listOfTires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] data = input.Split().Select(double.Parse).ToArray();
                int year1 = (int)data[0];
                double pressure1 = data[1];
                int year2 = (int)data[2];
                double pressure2 = data[3];
                int year3 = (int)data[4];
                double pressure3 = data[5];
                int year4 = (int)data[6];
                double pressure4 = data[7];

                Tire [] tires = new Tire[4]
                {
                new Tire(year1, pressure1),
                new Tire(year2, pressure2),
                new Tire(year3, pressure3),
                new Tire(year4, pressure4),
                };

                listOfTires.Add(tires);
            }

            string inputEngine = string.Empty;
            List<Engine> listOfEngine = new List<Engine>();

            while ((inputEngine = Console.ReadLine()) != "Engines done")
            {
                double[] data = inputEngine.Split().Select(double.Parse).ToArray();
                int horsePower = (int)data[0];
                double cubicCapacity = data[1];
                Engine currEngine = new Engine(horsePower,cubicCapacity);
                listOfEngine.Add(currEngine);
            }

            string inputCars = string.Empty;
            List<Car> listOfModels = new List<Car>();
            
            while ((inputCars = Console.ReadLine()) != "Show special")
            {
                string[] data = inputCars.Split().ToArray();

                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);

                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption, listOfEngine[engineIndex], listOfTires[tiresIndex]);
                listOfModels.Add(currCar);
            }

            List<Car> listOfSpecialCars = new List<Car>();

            for (int i = 0; i < listOfModels.Count; i++)
            {
                int currYear = listOfModels[i].Year;
                int currCarHorsePower = listOfModels[i].Engine.HorsePower;
                double sumTire = listOfModels[i].Tires.Sum(x => x.Pressure);               

                if (currYear >= 2017 && currCarHorsePower > 300 && sumTire >= 9 && sumTire <= 10)
                {
                    double spendQuantity = listOfModels[i].FuelConsumption / 100 * 20;
                    listOfModels[i].FuelQuantity -= spendQuantity;
                    listOfSpecialCars.Add(listOfModels[i]);
                }
            }

            foreach (var item in listOfSpecialCars)
            {
                Console.WriteLine($"Make: {item.Make}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Year: {item.Year}");
                Console.WriteLine($"HorsePowers: {item.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {item.FuelQuantity}");
            }
        }
    }
}