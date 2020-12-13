using System;

namespace NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameToCheck = string.Empty;
            int bestResult = 0;
            string bestName = string.Empty;

            while ((nameToCheck = Console.ReadLine()) != "Stop")
            {
                int currResult = 0;

                for (int i = 0; i < nameToCheck.Length; i++)
                {
                    int numSuggestion = int.Parse(Console.ReadLine());

                    var letters = nameToCheck.ToCharArray();
                    int asciiValue = letters[i];

                    if (asciiValue == numSuggestion)
                    {
                        currResult += 10;
                    }
                    else
                    {
                        currResult += 2;
                    }
                }

                if (currResult > bestResult)
                {
                    bestName = nameToCheck;
                    bestResult = currResult;
                }
            }

            Console.WriteLine($"The winner is {bestName} with {bestResult} points!");
        }
    }
}
