using System;

namespace foreignLanguages
{
    class forLanguage
    {
        static void Main(string[] args)
        {
            string language = Console.ReadLine();

            switch (language)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
