using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {

        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometar, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometar;
            this.TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void CalculateDistance(List<Car> listOfCars, string model, double amountOfKm)
        {
            var carToDrive = listOfCars.Single(x => x.Model == model);
            double fuelConsumptionPerKm = carToDrive.FuelConsumptionPerKilometer;
            double fuelAmount = carToDrive.FuelAmount;

            double fuelSpend = fuelConsumptionPerKm * amountOfKm;

            if (fuelAmount >= fuelSpend)
            {
                carToDrive.TravelledDistance += amountOfKm;
                carToDrive.FuelAmount -= fuelSpend;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive") ;
            }                 
        }
    }
}
