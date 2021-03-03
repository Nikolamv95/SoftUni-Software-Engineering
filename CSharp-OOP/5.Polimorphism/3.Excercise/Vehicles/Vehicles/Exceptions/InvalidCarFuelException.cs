using System;

namespace VehiclesV2.Exceptions
{
    public class InvalidCarFuelException : Exception
    {
        public const string CAR_FUEL_EXC_MSG = "Car needs refueling";
        public InvalidCarFuelException() : base(CAR_FUEL_EXC_MSG)
        {
        }

        public InvalidCarFuelException(string message) 
            : base(message)
        {
        }
    }
}
