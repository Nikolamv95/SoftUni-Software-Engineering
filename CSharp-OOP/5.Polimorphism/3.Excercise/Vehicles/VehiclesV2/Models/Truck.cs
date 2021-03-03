using VehiclesV2.Models;

namespace VehiclesV2
{
    public class Truck : Vehicle
    {
        private const double ADD_FUEL_CONSUMP = 1.6;
        private const double LOST_REFUEL_PORC = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelQuantity => base.FuelQuantity;
        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm;
        public override double AdditionalConsumption => ADD_FUEL_CONSUMP;

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
            base.FuelQuantity -= (1 - LOST_REFUEL_PORC) * amount;
        }
    }
}
