using System;

using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Product
    {
        //Fields
        private string name;
        private decimal cost;
        //Constructor
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        //Properties
        public string Name
        { 
            get 
            {
                return this.name;
            } 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMsg);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name; 
        }
    }
}
