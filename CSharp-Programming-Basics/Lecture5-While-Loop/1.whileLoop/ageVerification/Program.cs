using System;

namespace ageVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());

            while (true)
            {
                if (age >= 18)
                {
                    Console.WriteLine("You are the best:");
                    break;
                }

                Console.WriteLine("You don`t have permission");
                age = int.Parse(Console.ReadLine());
            }
        }
    }
}
