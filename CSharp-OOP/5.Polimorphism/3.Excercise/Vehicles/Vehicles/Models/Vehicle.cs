namespace VehiclesV2.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumptionPerKm { get; protected set; }

        public abstract void DriveVehicle(double distance);
        public abstract void RefuelVehicle(double fuelQuantity);
        public abstract string GetRemainingFuel();
    }
}
