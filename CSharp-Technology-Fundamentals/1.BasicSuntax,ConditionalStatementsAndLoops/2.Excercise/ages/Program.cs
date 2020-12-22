using System;

namespace ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());

            //0 - 2 – baby;
            //3 - 13 – child;
            //14 - 19 – teenager;
            //20 - 65 – adult;
            //    >= 66 – elder;
            //All the values are inclusive.


            if (ages >= 0 && ages <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (ages > 2 && ages <= 13)
            {
                Console.WriteLine("child");
            }
            else if (ages > 13 && ages <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (ages > 19 && ages <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (ages > 65)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
