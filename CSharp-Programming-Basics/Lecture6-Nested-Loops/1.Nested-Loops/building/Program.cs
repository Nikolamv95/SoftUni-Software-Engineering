using System;

namespace building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFloors = int.Parse(Console.ReadLine());
            int numberRooms = int.Parse(Console.ReadLine());

            for (int f = numberFloors; f >= 1; f--)
            {
                if (f % 2 != 0 && f != numberFloors)
                {
                    for (int a = 0; a < numberRooms; a++)
                    {
                        Console.Write($"A{f}{a} ");
                    }
                }
               else if (f % 2 == 0 && f != numberFloors)
                {
                    for (int o = 0; o < numberRooms; o++)
                    {
                        Console.Write($"O{f}{o} ");
                    }
                }
                else if (f == numberFloors)
                {
                    for (int l = 0; l < numberRooms; l++)
                    {
                        Console.Write($"L{f}{l} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
