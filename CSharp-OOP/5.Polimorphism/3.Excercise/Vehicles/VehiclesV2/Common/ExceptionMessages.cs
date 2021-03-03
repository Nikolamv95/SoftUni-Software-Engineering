using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesV2.Common
{
    public static class ExceptionMessages
    {
        public const string NOT_ENG_FUEL_MSG = "{0} needs refueling";
        public const string NEG_FUEL_MSG = "Fuel must be a positive number";
        public const string INV_VEHICLE_TYPE = "Invalid vehicle type";
        public const string FUEL_OUT_OF_LIMIT_MSG = "Cannot fit {0} fuel in the tank";
    }
}
