using System;

namespace CompareNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Nikola";
            string lastName = "Margaritov";

            //We can compare text only to check are thy similar or different
            Console.WriteLine(firstName == lastName);
            Console.WriteLine(firstName != lastName);
                
        }
    }
}
