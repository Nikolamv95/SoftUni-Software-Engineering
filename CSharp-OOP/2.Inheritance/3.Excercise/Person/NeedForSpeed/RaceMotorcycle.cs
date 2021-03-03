using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        private const double DefaultFuelConsumtion = 8.00;

        public override double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumtion;
            }
        }
    }
}
