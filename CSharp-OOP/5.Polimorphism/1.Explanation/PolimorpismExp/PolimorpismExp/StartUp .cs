using Shapes.Contracts;
using Shapes.Contracts.BaseClass;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape2 = new Rectangle(5,4);
            if (shape2 is Rectangle)
            {
                double num = ((Rectangle)shape2).Height; //On this way we cat objects. If the variable is from the base clas we can cast it to all it`s childs.
                //The best way to cast a object is with as
                Rectangle rect = shape2 as Rectangle;//If the cast is not happened it will throw null and you can check it with if statement if .... == nul do something
                double num2 = rect.Height;
            }


            while (true)
            {
                string input = Console.ReadLine();
                Shape shape = null;

                if (input == "Circle")
                {
                    shape = new Circle(5);
                }
                else if (input == "Rectangle")
                {
                    shape = new Rectangle(5,5);
                }
                Console.WriteLine(shape.Draw());
            }

        }
    }
}
