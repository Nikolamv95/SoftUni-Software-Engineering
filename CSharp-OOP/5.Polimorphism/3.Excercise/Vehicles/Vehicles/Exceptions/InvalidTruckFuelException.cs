using System;

namespace VehiclesV2.Exceptions
{
    public class InvalidTruckFuelException : Exception
    {
        public const string TRUCK_FUEL_EXC_MSG = "Truck needs refueling";
        public InvalidTruckFuelException() : base(TRUCK_FUEL_EXC_MSG)
        {
        }

        public InvalidTruckFuelException(string message)
            : base(message)
        {
        }
    }
}
