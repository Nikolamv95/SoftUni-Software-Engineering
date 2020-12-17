using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            ;
            //Input
            int grade1 = int.Parse(Console.ReadLine());
            int grade2 = int.Parse(Console.ReadLine());
            //If Function
       

            if (grade1 > grade2)
            {
                Console.WriteLine(grade1);
            }
            else
            {
                Console.WriteLine(grade2);
            }
        }
    }
}
