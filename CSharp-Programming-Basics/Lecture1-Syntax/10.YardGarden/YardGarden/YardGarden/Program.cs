using System;

namespace YardGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            double houseyard = double.Parse(Console.ReadLine());
            double price = 7.61;
            double pricehouseyard = houseyard * price;
            double discountprice = 0.18 * pricehouseyard;
            double finalprice = pricehouseyard - discountprice;
            Console.WriteLine($"The final price is: {finalprice} lv.");
            Console.WriteLine($"The discount is: {discountprice} lv.");
        }
    }
}
