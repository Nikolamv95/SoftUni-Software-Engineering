using System;
using System.Collections.Generic;
using System.Linq;

namespace cardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> deck1 = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            List<int> deck2 = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            while (deck1.Count != 0 && deck2.Count != 0)
            {

                int firstCardCheckDeck1 = deck1[0];
                int firstCardCheckDeck2 = deck2[0];

                if (firstCardCheckDeck1 > firstCardCheckDeck2)
                {
                    deck1.Add(firstCardCheckDeck1);
                    deck1.Add(firstCardCheckDeck2);
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
                else if (firstCardCheckDeck2 > firstCardCheckDeck1)
                {
                    deck2.Add(firstCardCheckDeck2);
                    deck2.Add(firstCardCheckDeck1);
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
                else if (firstCardCheckDeck1 == firstCardCheckDeck2)
                {
                    deck1.RemoveAt(0);
                    deck2.RemoveAt(0);
                }
            }

            if (deck1.Count > deck2.Count)
            {
                int sum = deck1.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = deck2.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
