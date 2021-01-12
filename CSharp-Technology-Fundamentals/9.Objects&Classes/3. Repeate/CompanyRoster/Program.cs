using System;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrase = { "Excellent product.", "Such a great product.", 
                                "I always use that product.", "Best product of its category.",
                                "Exceptional product.", "I can’t live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.", 
                                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int comments = int.Parse(Console.ReadLine());

            Random ran = new Random();

            for (int i = 0; i < comments; i++)
            {
                int phraseIndex = ran.Next(0, phrase.Length);
                int eventIndex = ran.Next(0, events.Length);
                int authorsIndex = ran.Next(0, authors.Length);
                int citiesIndex = ran.Next(0, cities.Length);

                Console.WriteLine($"{phrase[phraseIndex]} {events[eventIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}.");
            }
        }
    }
}
