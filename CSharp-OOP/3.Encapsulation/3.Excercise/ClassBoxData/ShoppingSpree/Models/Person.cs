using System;
using System.Collections.Generic;

using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Person
    {
        //Private messages
        private const string NotEnoughMoneyMsg = "{0} can't afford {1}";
        private const string IsPurchasedMsg = "{0} bought {1}";

        //Fields
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;//Да пробвам после да е стринг листа и да слагам само името на продукта вътре

        //Constructor
        public Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
                : this()
        {
            this.Name = name;
            this.Money = money;
            //или директно тук пишем this.Bag = new List<Product>();
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
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMsg);
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
        }
        //Methods
        public string Purchase(Product product)
        {
            if (this.Money < product.Cost)
            {
                return string.Format(NotEnoughMoneyMsg, this.Name, product.Name);
            }
            
            this.Money -= product.Cost;
            this.bag.Add(product);

            return string.Format(IsPurchasedMsg, this.Name, product.Name);
        }

        public override string ToString()
        {
            string producsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {producsOutput}"; 
        }

    }
}
