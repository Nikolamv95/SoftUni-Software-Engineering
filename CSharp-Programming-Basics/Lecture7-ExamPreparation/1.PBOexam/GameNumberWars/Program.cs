using System;

namespace GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string cardCom1;
            int pointsPlayer1 = 0;
            int pointPlayer2 = 0;
            bool isEntered = false;

            while ((cardCom1 = Console.ReadLine()) != "End of game")
            {
                int cardDeck1 = int.Parse(cardCom1);
                int cardDeck2 = int.Parse(Console.ReadLine());

                if (cardDeck1 > cardDeck2)
                {
                    pointsPlayer1 += cardDeck1 - cardDeck2;
                }
                else if (cardDeck2 > cardDeck1)
                {
                    pointPlayer2 += cardDeck2 - cardDeck1;
                }
                else if (cardDeck1 == cardDeck2)
                {
                    int newCard1 = int.Parse(Console.ReadLine());
                    int newCard2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Number wars!");
                    isEntered = true;

                    if (newCard1 > newCard2)
                    {
                        Console.WriteLine($"{name1} is winner with {pointsPlayer1} points");
                        break;
                    }
                    else if (newCard2 > newCard1)
                    {
                        Console.WriteLine($"{name2} is winner with {pointPlayer2} points");
                        break;
                    }
                }
            }

            if (isEntered == false)
            {
                Console.WriteLine($"{name1} has {pointsPlayer1} points"); 
                Console.WriteLine($"{name2} has {pointPlayer2} points"); 
            }
        }
    }
}
