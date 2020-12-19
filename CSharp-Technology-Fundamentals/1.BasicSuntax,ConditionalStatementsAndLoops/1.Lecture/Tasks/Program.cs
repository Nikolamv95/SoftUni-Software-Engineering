using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("{0} {1}", name, age);


            double number = 5.50003214;
            int number2 = 55;

            Console.WriteLine("{0:f2}",number);
            Console.WriteLine("{0:D3}",number2);

                

        }
    }
}
