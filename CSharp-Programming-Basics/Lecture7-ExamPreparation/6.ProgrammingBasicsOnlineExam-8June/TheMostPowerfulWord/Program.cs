using System;

namespace TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToCheck = string.Empty;
            int bestResult = 0;
            string bestWord = string.Empty;

            while ((wordToCheck = Console.ReadLine()) != "End of words")
            {
                int currResult = 0;
                bool isVowel = false;

                for (int i = 0; i < wordToCheck.Length; i++)
                {
                    var letters = wordToCheck.ToCharArray();

                    var firstLetter = letters[0].ToString().ToLower();

                    isVowel = firstLetter == "a" || firstLetter == "e"
                               || firstLetter == "i" || firstLetter == "o"
                               || firstLetter == "u" || firstLetter == "y";

                    int letterValue = letters[i];
                    currResult += letterValue;
                }

                if (isVowel == true)
                {
                    currResult = currResult * wordToCheck.Length;
                }
                else
                {
                    currResult = currResult / wordToCheck.Length;
                }

                if (currResult > bestResult)
                {
                    bestResult = currResult;
                    bestWord = wordToCheck;

                }
            }
            Console.WriteLine($"The most powerful word is {bestWord} - {bestResult}");
        }
    }
}
