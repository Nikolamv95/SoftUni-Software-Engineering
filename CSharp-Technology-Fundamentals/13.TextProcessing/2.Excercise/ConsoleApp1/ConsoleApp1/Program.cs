using System;
using System.Linq;
using System.Text;

namespace validUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i];
                //Създаваме метод в който правим проверката
                bool isValid = isEligible(word);

                if (isValid == true)
                {
                    sb.AppendLine(word);
                }
            }

            Console.WriteLine(sb);
        }

        public static bool isEligible(string word)
        {
            //Проверяваме дали условията са спазени. Погледни word.All с този метод проверяваме дали 
            //в думата се съдържа буква или цифра.
            return (word.Length >= 3 && word.Length <= 16 && word.All(c => char.IsLetterOrDigit(c)))
                   || word.Contains('-') 
                   || word.Contains('_');
        }
    }
}
