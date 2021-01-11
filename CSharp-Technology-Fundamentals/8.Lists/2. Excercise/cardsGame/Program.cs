using System;
using System.Collections.Generic;
using System.Linq;

namespace cardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cardDesk1 = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            List<int> cardDesk2 = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            while (cardDesk1.Count != 0 && cardDesk2.Count != 0)
            {

                int firstPlayerCard = cardDesk1[0];
                int secondPlayerCard = cardDesk2[0];

                if (firstPlayerCard > secondPlayerCard)
                {
                    cardDesk1.Add(firstPlayerCard);
                    cardDesk1.Add(secondPlayerCard);
                }
                else if (firstPlayerCard < secondPlayerCard)
                {
                    cardDesk2.Add(secondPlayerCard);
                    cardDesk2.Add(firstPlayerCard);
                }
                cardDesk1.RemoveAt(0);
                cardDesk2.RemoveAt(0);
            }

            if (cardDesk1.Count > cardDesk2.Count)
            {
                Console.WriteLine($"First player wins! {cardDesk1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! {cardDesk2.Sum()}");
            }
        }
    }
}
