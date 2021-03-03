using System;
using VehiclesV2.Exceptions;
using VehiclesV2.Models;

namespace VehiclesV2
{
    public class Car : Vehicle
    {
        private const double additinalFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
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
            this.FuelQuantity += fuelQuantity;
        }
        public override string GetRemainingFuel()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
        private void FuelValidation(double neededFuel, double distance)
        {
            if (neededFuel > FuelQuantity)
            {
                throw new InvalidCarFuelException();
            }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
            }
        }
    }
}
