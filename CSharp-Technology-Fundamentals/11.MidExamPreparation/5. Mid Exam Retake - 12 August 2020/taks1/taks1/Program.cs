using System;

namespace taks1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double priceNoTax = 0;
            double taxes = 0;
            double totalPrice = 0;

            while (input != "special" && input != "regular")
            {
                double number = double.Parse(input);

                if (number >= 0)
                {
                    priceNoTax += number;
                }
                else
                {
                    Console.WriteLine("Invalid price!"); 
                }
                
                input = Console.ReadLine();
            }


            taxes = priceNoTax * 0.20;
            totalPrice = priceNoTax + taxes;


            if (input == "special")
            {
                totalPrice *= 0.90;

                if (totalPrice == 0)
                {
                    Console.WriteLine("Invalid order!");
                }
                else
                {
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {priceNoTax:f2}$");
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {totalPrice:f2}$");
                }
            }
            else if (input == "regular")
            {
                if (totalPrice == 0)
                {
                    Console.WriteLine("Invalid order!");
                }
                else
                {
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {priceNoTax:f2}$");
                    Console.WriteLine($"Taxes: {taxes:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {totalPrice:f2}$");
                }
            }
        }
    }
}
