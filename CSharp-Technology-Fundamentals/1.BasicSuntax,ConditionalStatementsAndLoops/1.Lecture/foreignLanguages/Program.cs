using System;

namespace foreignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string language = Console.ReadLine();

            if (language == "England" || language == "USA")
            {
                Console.WriteLine("English");
            }
            else if (language == "Spain" || language == "Argentina" || language == "Mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
