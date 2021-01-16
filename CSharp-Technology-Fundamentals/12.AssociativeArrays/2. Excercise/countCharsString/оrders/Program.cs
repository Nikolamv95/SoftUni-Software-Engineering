using System;
using System.Collections.Generic;

namespace оrders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Създаваме речник с Key -> string и Value -> List. Това го правим защото трябва да запазим повече от 
            //1 стойност във Value частта. Реално всеки стринг си има отделен списък с отделни стойностии
            Dictionary<string, List<double>> listOfProducts = new Dictionary<string, List<double>>();

            string command = Console.ReadLine();

            //Създаваме цикъл за обработка на данни и операции
            while (command != "buy")
            {
                string[] currProducts = command.Split();
                string product = currProducts[0];
                double price = double.Parse(currProducts[1]);
                double quantity = double.Parse(currProducts[2]);

                //Проверяваме продукта дали съществува
                if (listOfProducts.ContainsKey(product) == false)
                {
                    //Ако не съществува добавяме стойностите му, като в листа добавяме цена и количество
                    //за конкретния стринг
                    List<double> priceAndQuantity = new List<double> { price, quantity };
                    listOfProducts.Add(product, priceAndQuantity);
                }
                else
                {
                    //ИЗКЛЮЧИТЕЛНО ВАЖНО!!!
                    //Ако вече съществува за конкретния продукт добавяме стойностите цена и количество като с
                    //[index] достъпваме стойностите в списъка който вече сме запаметили
                    listOfProducts[product][0] = price;
                    listOfProducts[product][1] += quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var item in listOfProducts)
            {
                //Изчисляваме total price и печатаме.
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
