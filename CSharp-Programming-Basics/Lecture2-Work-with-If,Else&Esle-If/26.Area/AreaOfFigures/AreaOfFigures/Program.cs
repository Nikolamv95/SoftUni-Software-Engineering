using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            //square
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double round = side * side;
                Console.WriteLine($"{round:f3}");
            }

            //rectangle
            else if (figure == "rectangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double side = double.Parse(Console.ReadLine());
                double full = lenght * side;
                Console.WriteLine($"{full:f3}");
            }

            //circle
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * Math.Pow(radius,2);
                Console.WriteLine($"{area:f3}");
            }

            //triangle
            else if (figure == "triangle")
            {
                double sideLenght = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double faceTriangle = (sideLenght * height) / 2;
                Console.WriteLine($"{faceTriangle:f3}");
            }
        }
    }
}
