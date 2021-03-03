using FluentInterface.Models;
using System;

namespace FluentInterface
{
    //With fluentInterface pattern we create objects by chaining they BuildMethods which we created already.
    //This pattern works very good with BuilderPattern.
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            CarBuilder builder = new CarBuilder();
            builder.BuildEngine(car).BuildTransmission(car).BuildTyres(car);
            Console.WriteLine(car.Engine);
            Console.WriteLine(car.Transmission);
            Console.WriteLine(car.Tyres);
        }
    }
}
