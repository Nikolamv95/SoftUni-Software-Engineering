using System;

namespace moving
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която изчислява свободния обем от жилището на Хосе, който остава след като пренесе багажа си.
            //Бележка: Един кашон е с точни размери:  1m.x 1m.x 1m.

            //⦁	Широчина на свободното пространство -цяло число в интервала[1...1000]
            //⦁	Дължина на свободното пространство -цяло число в интервала[1...1000]
            //⦁	Височина на свободното пространство -цяло число в интервала[1...1000]
            //⦁	На следващите редове(до получаване на команда "Done") - брой кашони, които се пренасят в квартирата - цели числа в интервала[1...10000];

            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int freesSpace = widht * lenght * height;
            int usedSpace = 0;

            while (usedSpace < freesSpace || input != "Done")
            {
                int quantity = Convert.ToInt32(input);
                usedSpace += quantity;

                input = Console.ReadLine();
            }
        }
    }
}
