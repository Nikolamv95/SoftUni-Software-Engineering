using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double defaultCoffeeMilliliters = 50;
        private const decimal defaultCoffePrice = 3.50m;

        public Coffee(string name, double caffeine) : base(name, defaultCoffePrice, defaultCoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }
        
        public double Caffeine { get; set; }
    }
}