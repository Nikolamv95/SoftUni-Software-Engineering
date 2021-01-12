using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    class Vehicle
    {   //Стъпка 2 - Създаваме конструктор
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        //Стъпка 1 дефинираме пропъртитата
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        //Стъпка 3 Override-ваме текста който трябва да печатаме на конзолата
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"HorsePower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }

    }
}
