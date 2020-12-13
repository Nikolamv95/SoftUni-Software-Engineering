using System;
using System.Linq;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = string.Empty;
            string bestMovie = string.Empty;
            int bestPoints = 0;
            int counter = 0;

            while ((movieName = Console.ReadLine()) != "STOP")
            {
                counter += 1;
                int currPoints = 0;

                if (counter == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
                else
                {
                    var letterMovie = movieName.ToCharArray();
                    
                    for (int i = 0; i < letterMovie.Length; i++)
                    {
                        if (letterMovie[i] != ' ')
                        {
                            if (Char.IsUpper(letterMovie[i]))
                            {
                                int points = letterMovie[i] - letterMovie.Length;
                                currPoints += points;
                            }
                            else if (Char.IsLower(letterMovie[i]))
                            {
                                int points = letterMovie[i] - (letterMovie.Length * 2);
                                currPoints += points;
                            }
                            else if (Char.IsDigit(letterMovie[i]))
                            {
                                int points = letterMovie[i];
                                currPoints += points;
                            }
                        }
                        else
                        {
                            currPoints += 32;
                        }
                                                
                    }
                }

                if (currPoints > bestPoints)
                {
                    bestPoints = currPoints;
                    bestMovie = movieName;
                }
            }
            Console.WriteLine($"The best movie for you is {bestMovie} with {bestPoints} ASCII sum.");
        }
    }
}
