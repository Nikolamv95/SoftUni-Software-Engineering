using PizzaCalories.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split().ToArray();
            string pizzaName = pizzaInput[1];

            try
            {
                string[] doughInput = Console.ReadLine().Split().ToArray();
                string doughFlour = doughInput[1];
                string doughBackeTechnique = doughInput[2];
                double dougWeigth = double.Parse(doughInput[3]);
                Dough dough = new Dough(doughFlour, doughBackeTechnique, dougWeigth);
                Pizza pizza = new Pizza(pizzaName, dough);
                List<Topping> toppingList = new List<Topping>();

                while (true)
                {
                    string[] toppintInput = Console.ReadLine().Split().ToArray();

                    if (toppintInput[0] == "END")
                    {
                        break;
                    }

                    string toppingName = toppintInput[1];
                    double toppingWeigth = double.Parse(toppintInput[2]);

                    Topping currTopping = new Topping(toppingName, toppingWeigth);
                    toppingList.Add(currTopping);
                }

                pizza.AddToppings(toppingList);
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories(dough):f2} Calories.");

            }
            catch (ArgumentException se)
            {

                Console.WriteLine(se.Message);
            }
           
            

        }
    }
}
