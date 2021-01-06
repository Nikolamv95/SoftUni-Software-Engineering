using System;

namespace refactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.Write($"Length: Width: Height: ");

            double volume = 0;
            volume = (lenght * width * height) / 3;

            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}
