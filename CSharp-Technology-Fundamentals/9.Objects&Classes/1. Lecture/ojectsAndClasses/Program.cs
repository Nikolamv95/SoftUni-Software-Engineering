using System;

namespace ojectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice6 = new Dice(6);
            Dice dice20 = new Dice(20);
            //dice6.Sides = 6;


            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(dice6.Roll());
            }
            Console.WriteLine("STOP");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(dice20.Roll());
            }
            Console.WriteLine("STOP");

        }
    }
}
