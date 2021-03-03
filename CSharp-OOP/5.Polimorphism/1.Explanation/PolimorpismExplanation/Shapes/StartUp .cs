using Shapes.Contracts;
using Shapes.Contracts.BaseClass;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape baseClass = new Circle(5);
            Console.WriteLine(baseClass.Draw());
            Console.WriteLine(baseClass.GetType());

            baseClass = new Rectangle(3,2);
            Console.WriteLine(baseClass.Draw());
            Console.WriteLine(baseClass.GetType());
        }
    }
}
