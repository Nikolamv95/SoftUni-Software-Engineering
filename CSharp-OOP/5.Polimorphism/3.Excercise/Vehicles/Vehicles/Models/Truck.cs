using System;
using VehiclesV2.Exceptions;
using VehiclesV2.Models;

namespace VehiclesV2
{
    public class Truck : Vehicle
    {
        private const double additinalFuelConsumption = 1.6;
        private const double lostFuel = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            this.FuelConsumptionPerKm += additinalFuelConsumption;
        }

        public override void DriveVehicle(double distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKm;
            FuelValidation(neededFuel, distance);
            this.FuelQuantity -= neededFuel;
        }

        public override void RefuelVehicle(double fuelQuantity)
        {
            fuelQuantity = fuelQuantity * lostFuel;
            this.FuelQuantity += fuelQuantity;
        }

        public override string GetRemainingFuel()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }

        private void FuelValidation(double neededFuel, double distance)
        {
            if (neededFuel > FuelQuantity)
            {
                throw new InvalidTruckFuelException();
            }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }
    }
}
