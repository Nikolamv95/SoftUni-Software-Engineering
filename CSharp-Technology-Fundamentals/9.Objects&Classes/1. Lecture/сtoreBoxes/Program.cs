using storeBoxes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace сtoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Box> listBoxes = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] productInput = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string itemSerialNumber = productInput[0];
                string itemName = productInput[1];
                int itemQuantity = int.Parse(productInput[2]);
                decimal itemPrice= decimal.Parse(productInput[3]);
                decimal totalPrice = itemPrice * itemQuantity;

                Box newBox = new Box();

                newBox.SerialNumber = itemSerialNumber;
                newBox.Item = itemName;
                newBox.ItemQuantity = itemQuantity;
                newBox.PricePerBox = itemPrice;
                newBox.TotalPrice = totalPrice;

                listBoxes.Add(newBox);
            }

            List<Box> sortedBox = listBoxes.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedBox.Reverse();

            foreach (Box boxToPrint in sortedBox)
            {
                Console.WriteLine($"{boxToPrint.SerialNumber}");
                Console.WriteLine($"-- {boxToPrint.Item} – ${boxToPrint.PricePerBox}: {boxToPrint.ItemQuantity}");
                Console.WriteLine($"-- ${boxToPrint.TotalPrice:f2}");
            }
        }
    }
}
