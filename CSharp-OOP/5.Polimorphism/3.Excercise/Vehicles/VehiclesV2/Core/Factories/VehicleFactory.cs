using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.Common;
using VehiclesV2.Models;

namespace VehiclesV2.Core.Factories
{
    //FACTORY PATTERN - LEARN MORE
    public class VehicleFactory
    {
        //MOST OF THE TIME YOU CAN DO IT WITH REFLECT
        public Vehicle CreateVehicle(string vehicleType, double fuelQuan, double fuelConsumpt, double tankCapacity)
        {
            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuan, fuelConsumpt, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuan, fuelConsumpt, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuan, fuelConsumpt, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INV_VEHICLE_TYPE);
            }

            return vehicle;
        }
    }
}
