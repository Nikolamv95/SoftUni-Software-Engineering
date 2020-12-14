using System;

namespace moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int freesSpace = widht * lenght * height;
            int usedSpace = 0;

            while (input != "Done")
            {
                int quantity = Convert.ToInt32(input);

                usedSpace += quantity;
                
                if (usedSpace > freesSpace)
                {
                    Console.WriteLine($"No more free space! You need {usedSpace - freesSpace} Cubic meters more.");
                    Environment.Exit(0);
                }

                input = Console.ReadLine();
            }

            freesSpace = freesSpace - usedSpace;
            Console.WriteLine($"{freesSpace} Cubic meters left.");
        }
    }
}
