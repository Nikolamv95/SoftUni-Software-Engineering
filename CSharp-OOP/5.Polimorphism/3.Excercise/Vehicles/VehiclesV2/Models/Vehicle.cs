using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.Common;
using VehiclesV2.Models.Contracts;

namespace VehiclesV2.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        //Fields
        private const string drivenDistance = "{0} travelled {1} km";
        private double fuelQuantity = 0;

        //COnstructors
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumptionPerKm = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        //Properties
        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumptionPerKm { get;}
        public virtual double AdditionalConsumption { get; protected set; }
        public double TankCapacity { get; }

        //Methods - Actions
        public virtual string Drive(double amount)
        {
            double fuelNeeded = (this.FuelConsumptionPerKm + AdditionalConsumption) * amount;
            FuelNeededValidation(fuelNeeded);

            this.FuelQuantity -= fuelNeeded;
            return string.Format(drivenDistance, this.GetType().Name, amount);
        }
        public virtual void Refuel(double amount)
        {
            NegativeAmountValidation(amount);
            TankCapacityValidation(amount);

            this.FuelQuantity += amount;
        }

        //Methods - Validations
        private void FuelNeededValidation(double fuelNeeded)
        {
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.NOT_ENG_FUEL_MSG, this.GetType().Name));
            }
        }
        private void TankCapacityValidation(double amount)
        {
            if (this.TankCapacity < (amount + this.fuelQuantity))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.FUEL_OUT_OF_LIMIT_MSG, amount));
            }
        }
        private static void NegativeAmountValidation(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NEG_FUEL_MSG);
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
