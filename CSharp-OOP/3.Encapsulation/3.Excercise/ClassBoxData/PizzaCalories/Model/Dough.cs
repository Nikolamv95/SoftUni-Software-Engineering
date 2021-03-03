using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Model
{
    public class Dough
    {
        //Private messages
        private const double GeneralCalPerGrDoug = 2;
        private const string WeigthExcMsg = "Dough weight should be in the range [1..200].";
        private const string TypeDoughExcMsg = "Invalid type of dough.";

        //Fields
        private string flourType;
        private string bakingTechnique;
        private double weigth;
        private double calories;

        //Constructor
        public Dough(string flourType, string bakingTechnique, double weigth)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weigth = weigth;
            this.Calories = calories;
        }

        //Properties
        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (IsFlourValid(value) == false)
                {
                    throw new ArgumentException(TypeDoughExcMsg);
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (IsTechniqueValid(value) == false)
                {
                    throw new ArgumentException(TypeDoughExcMsg);
                }

                this.bakingTechnique = value;
            }
        }

        private double Weigth
        {
            get
            {
                return this.weigth;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeigthExcMsg);
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
        private bool IsFlourValid(string flourType)
        {
            bool isValideFlour = false;

            switch (flourType.ToLower())
            {
                case "white":
                    isValideFlour = true;
                    break;
                case "wholegrain":
                    isValideFlour = true;
                    break;
            }

            return isValideFlour;
        }

        private bool IsTechniqueValid(string bakingTechnique)
        {
            bool isValideTechnique = false;

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    isValideTechnique = true;
                    break;
                case "chewy":
                    isValideTechnique = true;
                    break;
                case "homemade":
                    isValideTechnique = true;
                    break;
            }

            return isValideTechnique;
        }

        private double CalculateCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier(this.FlourType);
            double bakingTechniqueModifier = GetBakingTechniqueModifier(this.BakingTechnique);
            double doughCalories = (GeneralCalPerGrDoug * this.Weigth) * flourTypeModifier * bakingTechniqueModifier;

            return doughCalories;
        }

        private double GetBakingTechniqueModifier(string bakingTechnique)
        {
            double result = 0;

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    result = 0.9;
                    break;
                case "chewy":
                    result = 1.1;
                    break;
                case "homemade":
                    result = 1.0;
                    break;
            }

            return result;
        }

        private double GetFlourTypeModifier(string flourType)
        {
            double result = 0;

            if (flourType.ToLower() == "white")
            {
                result = 1.5;
            }
            else if (flourType.ToLower() == "wholegrain")
            {
                result = 1.0;
            }

            return result;
        }
    }
}
