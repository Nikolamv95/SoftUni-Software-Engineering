using System;

namespace randomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            for (int i = 0; i < wordsArray.Length; i++)
            {
                int index = rnd.Next(0, wordsArray.Length);
                string wordToSave = wordsArray[i];
                wordsArray[i] = wordsArray[index];
                wordsArray[index] = wordToSave;
            }

            Console.WriteLine(string.Join(Environment.NewLine, wordsArray));
        }
    }
}
