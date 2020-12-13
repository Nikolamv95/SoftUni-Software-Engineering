using System;

namespace Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double hight = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double notPaint = double.Parse(Console.ReadLine());
            string paintL = string.Empty;
            
            double areaToPaint = hight * width * 4;
            double notPaintArea = notPaint / 100;
            areaToPaint = areaToPaint - (areaToPaint * notPaintArea);

            bool isDone = false;

            while ((paintL = Console.ReadLine()) != "Tired!")
            {
                double litersOfPaint = double.Parse(paintL);
                areaToPaint -= litersOfPaint;

                if (areaToPaint < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(areaToPaint)} l paint left!");
                    isDone = true;
                    break;
                }
                else if (areaToPaint == 0)
                {
                    Console.WriteLine($"All walls are painted! Great job, Pesho!");
                    isDone = true;
                    break;
                }
            }

            if (isDone == false)
            {
                Console.WriteLine($"{areaToPaint} quadratic m left.");
            }
        }
    }
}
