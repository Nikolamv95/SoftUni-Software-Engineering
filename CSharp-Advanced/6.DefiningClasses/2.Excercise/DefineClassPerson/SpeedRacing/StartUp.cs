using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ').ToArray();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionFor1kmt = double.Parse(data[2]);
                double travelledDistance = 0;

                Car currCar = new Car(model, fuelAmount, fuelConsumptionFor1kmt, travelledDistance);
                listOfCars.Add(currCar);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(' ').ToArray();
                string model = data[1];
                double amountOfKmDrive = double.Parse(data[2]);

                Car currCar = new Car();
                currCar.CalculateDistance(listOfCars, model, amountOfKmDrive);
            }

            foreach (var item in listOfCars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
