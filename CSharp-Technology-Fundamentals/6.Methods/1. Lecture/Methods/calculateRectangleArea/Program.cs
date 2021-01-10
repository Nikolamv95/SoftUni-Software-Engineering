using System;

namespace calculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int result = 0;

            result = Calculations(width, height);
            Console.WriteLine(result);
        }

        private static int Calculations(int width, int height)
        {
            return width * height;
        }
    }
}
