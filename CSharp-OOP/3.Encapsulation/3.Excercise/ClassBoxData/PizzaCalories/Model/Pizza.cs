using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Model
{
    public class Pizza
    {
        //Private messages
        private const string InvalidPizzaExcMsg = "Pizza name should be between 1 and 15 symbols.";
        private const string OverLimitToppingsExcMsg = "Number of toppings should be in range [0..10].";

        //Fields
        private string name;
        private readonly ICollection<Topping> toppingList;
        private Dough dough;

        //Constructor
        public Pizza()
        {
            this.toppingList = new List<Topping>();
        }
        public Pizza(string name, Dough dough) 
            : this()
        {
            this.Name = name;
            this.Dough = Dough;
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
                if (value.Length <1 
                                || value.Length > 15 
                                || string.IsNullOrWhiteSpace(value) 
                                || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidPizzaExcMsg);
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get 
            {
                return this.dough;
            }
            set 
            {
                this.dough = value;
            }
        }
        public IReadOnlyCollection<Topping> ToppingList
        {
            get
            {
                return (IReadOnlyCollection<Topping>)this.toppingList;
            }
        }

        //Methods
        public void AddToppings(List<Topping> addedToppings)
        {
            
            foreach (var item in addedToppings)
            {
                if (this.toppingList.Count < 10 )
                {
                    this.toppingList.Add(item);
                }
                else
                {
                    throw new ArgumentException(OverLimitToppingsExcMsg);
                }
            }
        }
        public double TotalCalories(Dough dough)
        {
            double doughCalories = dough.Calories;
            double totalToppingCalories = 0;

            foreach (var item in this.toppingList)
            {
                totalToppingCalories += item.Calories;
            }

            return doughCalories + totalToppingCalories;
        }

    }
}
