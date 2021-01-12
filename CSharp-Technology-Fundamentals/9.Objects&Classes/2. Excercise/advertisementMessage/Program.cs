using System;

namespace advertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMessages = int.Parse(Console.ReadLine());

            string[] phrase = {"Excellent product.", "Such a great product.",
                               "I always use that product.", "Best product of its category.",
                               "Exceptional product.", "I can’t live without this product."};


            string[] events = {"Now I feel good.", "I have succeeded with this product.",
                               "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                               "Try it yourself, I am very satisfied.", "I feel great!"};

            string[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};


            string[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            Random phraseTake = new Random();
            Random eventsTake = new Random();
            Random authorsTake = new Random();
            Random citiesTake = new Random();

            for (int i = 1; i <= numMessages; i++)
            {
                int indexPhrase = phraseTake.Next(0, phrase.Length-1);
                int indexEvents = eventsTake.Next(0, phrase.Length-1);
                int indexAuthors = authorsTake.Next(0, phrase.Length-1);
                int indexCities = citiesTake.Next(0, phrase.Length-1);

                Console.WriteLine($"{phrase[indexPhrase]} {events[indexEvents]} {authors[indexAuthors]} – {cities[indexCities]}.");
            }
        }
    }
}
