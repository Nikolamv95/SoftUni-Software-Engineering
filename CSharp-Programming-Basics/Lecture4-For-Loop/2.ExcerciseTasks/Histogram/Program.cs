using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {

            double n = int.Parse(Console.ReadLine());
            int under200 = 0;
            int under399 = 0;
            int under599 = 0;
            int under799 = 0;
            int over800 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number <= 199)
                {
                    under200 += 1;
                }
                else if (number <= 399)
                {
                    under399 += 1;
                }
                else if (number <= 599)
                {
                    under599 += 1;
                }
                else if (number <= 799)
                {
                    under799 += 1;
                }
                else if (number >= 800)
                {
                    over800 += 1;
                }
            }

            double percentage200 = 0;
            double percentage399 = 0;
            double percentage599 = 0;
            double percentage799 = 0;
            double percentage800 = 0;


            percentage200 = under200 / n * 100;
            percentage399 = under399 / n * 100;
            percentage599 = under599 / n * 100;
            percentage799 = under799 / n * 100;
            percentage800 = over800 / n * 100;

            Console.WriteLine($"{percentage200:f2}%");
            Console.WriteLine($"{percentage399:f2}%");
            Console.WriteLine($"{percentage599:f2}%");
            Console.WriteLine($"{percentage799:f2}%");
            Console.WriteLine($"{percentage800:f2}%");
        }
    }
}
