using System;
using System.Linq;


namespace lettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {

                var wordToWork = input[i].ToCharArray();

                //Take the firstLetter
                char firstLetter = wordToWork[0];

                //*Take the number
                string middleLetters = string.Empty;
                for (int j = 1; j < wordToWork.Length-1; j++)
                {
                    middleLetters += wordToWork[j];
                }
                decimal number = decimal.Parse(middleLetters);
                //*Number already taken

                //Take the lastLetter
                char lastLetter = wordToWork[wordToWork.Length-1];

                decimal letterPosition = 0;
                decimal sum = 0;

                //FIRST LETTER TO CHECK
                //Char is upper
                if (Char.IsUpper(firstLetter) == true)
                {
                    letterPosition = (decimal)firstLetter % 32;
                    sum = number / letterPosition;
                    totalSum += sum;
                }
                else
                {//Char is lower
                    letterPosition = (decimal)firstLetter % 32;
                    sum = number * letterPosition;
                    totalSum += sum;
                }

                //LAST LETTER TO CHECK
                //Char is upper
                if (Char.IsUpper(lastLetter) == true)
                {
                    letterPosition = (decimal)lastLetter % 32;
                    totalSum -= letterPosition;
                }
                else
                {//Char is lower
                    letterPosition = (decimal)lastLetter % 32;
                    totalSum += letterPosition;
                }
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
