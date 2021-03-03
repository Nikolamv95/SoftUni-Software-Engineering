namespace VehiclesV2
{
    public interface IVehicle
    {
        void DriveVehicle(double distance);
        void RefuelVehicle(double fuelQuantity);
        string GetRemainingFuel();
    }
}
