using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        private const double DefaultFuelConsumtion = 3.00;

        public override double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumtion;
            }
        }
    }
}
