using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> listOfMovies = new Dictionary<string, double>();
            int numMovies = int.Parse(Console.ReadLine());

            for (int i = 0; i < numMovies; i++)
            {
                string movie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                listOfMovies.Add(movie, rating);
            }

            double averageRating = listOfMovies.Values.Average();
            var topMoviesRang = listOfMovies.OrderByDescending(x => x.Value);
            var badMoviesRang = listOfMovies.OrderBy(x => x.Value);

            foreach (var item in topMoviesRang)
            {
                Console.WriteLine($"{item.Key} is with highest rating: {item.Value:f1}");
                break;
            }

            foreach (var item in badMoviesRang)
            {
                Console.WriteLine($"{item.Key} is with lowest rating: {item.Value:f1}");
                break;
            }

            Console.WriteLine($"Average rating: {averageRating:f1}");

        }
    }
}
