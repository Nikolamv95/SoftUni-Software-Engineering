using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.Models;

namespace VehiclesV2
{
    public class Car : Vehicle
    {
        private const double ADD_FUEL_CONSUMP = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm;
        public override double AdditionalConsumption => ADD_FUEL_CONSUMP;

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
    }
}
