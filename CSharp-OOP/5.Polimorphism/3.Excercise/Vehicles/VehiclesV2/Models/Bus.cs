using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.Models.Contracts;

namespace VehiclesV2.Models
{
    public class Bus : Vehicle
    {
        private const double ADD_FUEL_CONSUMP = 1.4;
        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
                            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm;
        public override double AdditionalConsumption => base.AdditionalConsumption + ADD_FUEL_CONSUMP;
        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
        public override string Drive(double amount)
        {
            return base.Drive(amount);
        }
        internal void SwitchOffAirConditioner()
        {
            base.AdditionalConsumption -= ADD_FUEL_CONSUMP;
        }
        internal void SwitchOnAirConditioner()
        {
            base.AdditionalConsumption += ADD_FUEL_CONSUMP;
        }
    }
}
