using System;

namespace kaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Стъпка 1 - декларираме дължината на DNK
            int lenghtOfDnk = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int counter = 0;
            int bestCount = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            string bestSequence = "";
            int bestCounter = 0;

            //Стъпка 2 - Създаваме While цикъл и го въртим докато не въведем стройност - Clone them!
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                // Създаваме нова променлива в която ще се запише Input.стринг без ! и space.
                string sequence = input.Replace("!", "");
                // Премахваме спейсовете и нулите от стринга sequence и ги записваме като стойности в масива dnaParts.
                string[] dnaParts = sequence.Split("0", 
                                    StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                string bestSubSequence = string.Empty;
                counter ++;

                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }

                int beginIndex = sequence.IndexOf(bestSubSequence);

                if (count > bestCount ||
                   (count == bestCount && beginIndex < bestBeginIndex) ||
                   (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum) || counter == 1)
                {
                    bestCount = count;
                    bestSequence = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = counter;
                }
            }

            char[] result = bestSequence.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}
