using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public double ItemQuantity { get; set; }
        public double PricePerBox { get; set; }
        public double TotalPrice { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Box> listOfBoxes = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string serialNumber = data[0];
                string item = data[1];
                double itemQuantity = double.Parse(data[2]);
                double price = double.Parse(data[3]);
                double totalPrice = itemQuantity * price;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item = item;
                box.ItemQuantity = itemQuantity;
                box.PricePerBox = price;
                box.TotalPrice = totalPrice;

                listOfBoxes.Add(box);
            }

            var filteredList = listOfBoxes.OrderByDescending(x => x.TotalPrice);

            foreach (var item in filteredList)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item} - ${item.PricePerBox:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.TotalPrice:f2}");
            }
        }
    }
}
