using System;

namespace characterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var firstWord = input[0];
            var secondWord = input[1];

            //Проверяваме коя дума е по-голяма от двете
            if (firstWord.Length >= secondWord.Length)
            {
                //Създаваме метод който получава резултата и печатаме
                int result = charMultiFirstWord(firstWord, secondWord);
                Console.WriteLine(result);
            }
            else
            {   //Създаваме метод който получава резултата и печатаме
                int result = charMultiSecondWord(firstWord, secondWord);
                Console.WriteLine(result);
            }
        }

        //В този случай втората дума е по-голяма от първата
        private static int charMultiSecondWord(string firstWord, string secondWord)
        {   //Създаваме променлива в която държим резултата
            var sum = 0;

            //В първия фор цикъл умножаваме стойностите на символите в двете думи
            //като цикъла приключва когато по-късата дума (Първата) свърши чаровете си.
            for (int i = 0; i < firstWord.Length; i++)
            {
                //Умножаваме чар 1 от дума 1 с чар 1 от дума 2
                var multiply = firstWord[i] * secondWord[i];
                //Добавяме към сумата
                sum += multiply;
            }

            //Във втория фор цикъл добавяме към Sum стойностите на чаровете през които
            //горния фор цикъл не е минал през по-дългата дума (втората)
            //Пример дума 1 -> аа | дума 2 -> ааббцц -> останалите букви са ббцц
            for (int i = firstWord.Length; i < secondWord.Length; i++)
            {
                sum += secondWord[i];
            }
            return sum;
        }

        //В този случай първата дума е по-голяма от първата
        private static int charMultiFirstWord(string firstWord, string secondWord)
        {   //Създаваме променлива в която държим резултата
            var sum = 0;

            for (int i = 0; i < secondWord.Length; i++)
            {
                var multiply = firstWord[i] * secondWord[i];
                sum += multiply;
            }

            for (int i = secondWord.Length; i < firstWord.Length; i++)
            {
                sum += firstWord[i];
            }

            return sum;
        }
    }
}
