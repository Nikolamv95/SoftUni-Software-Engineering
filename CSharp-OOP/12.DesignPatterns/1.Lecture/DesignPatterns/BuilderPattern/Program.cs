using BuilderPattern.Models;
using System;

namespace BuilderPattern
{
    //Builder pattern split the building procces of an object on BuilderMethods which will build the different parts of the object.
    //For example sometimes we want to create car only with engine without the rest of the parts of it.
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            CarBuilder carBuilder = new CarBuilder();
            carBuilder.BuildEngine(car);
            carBuilder.BuildTransmission(car);
            carBuilder.BuildTyres(car);

            Console.WriteLine(car.Engine);
            Console.WriteLine(car.Transmission);
            Console.WriteLine(car.Tyres);
        }
    }
}
