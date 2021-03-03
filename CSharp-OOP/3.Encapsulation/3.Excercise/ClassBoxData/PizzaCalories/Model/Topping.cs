using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Model
{
    public class Topping
    {
        //Private messages
        private const double GeneralCalPerGrTop = 2;
        private const string WeigthExcMsg = "{0} weight should be in the range [1..50].";
        private const string TypeTopExcMsg = "Cannot place {0} on top of your pizza.";

        //Fields
        private string toppingType;
        private double weigth;
        private double calories;

        //Constructor
        public Topping(string toppingType, double weigth)
        {
            this.ToppingType = toppingType;
            this.Weigth = weigth;
            this.Calories = calories;
        }

        //Properties
        private string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (IsTypeValid(value) == false)
                {
                    string argument = value;
                    throw new ArgumentException(String.Format(TypeTopExcMsg, value));
                }
                this.toppingType = value;
            }
        }4

        private double Weigth
        {
            get
            {
                return this.weigth;
            }
           set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(WeigthExcMsg, this.ToppingType));
                }
                this.weigth = value;
            }
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                this.calories = CalculateCalories();
            }
        }

        //Methods
        private double CalculateCalories()
        {
            double result = 0;

            return result = (GeneralCalPerGrTop * this.weigth) * TopTypeModifier(this.ToppingType);
        }

        private double TopTypeModifier(string toppingType)
        {
            double result = 0;

            switch (toppingType.ToLower())
            {
                case "meat":
                    result = 1.2;
                    break;
                case "veggies":
                    result = 0.8;
                    break;
                case "cheese":
                    result = 1.1;
                    break;
                case "sauce":
                    result = 0.9;
                    break;
            }

            return result;
        }

        private bool IsTypeValid(string toppingType)
        {
            bool isValid = false;
            switch (toppingType.ToLower())
            {
                case "meat":
                    isValid = true;
                    break;
                case "veggies":
                    isValid = true;
                    break;
                case "cheese":
                    isValid = true;
                    break;
                case "sauce":
                    isValid = true;
                    break;
            }

            return isValid;
        }
    }
}
