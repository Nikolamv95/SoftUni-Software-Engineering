using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int energyLeft = int.Parse(Console.ReadLine());
            int wonBattles = 0;
            bool isAlive = true;

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                int distanceEnemy = int.Parse(input);

                if (energyLeft >= distanceEnemy)
                {
                    energyLeft -= distanceEnemy;
                    wonBattles += 1;

                    if (wonBattles % 3 == 0)
                    {
                        energyLeft += wonBattles;
                    }
                }
                else
                {                                                                  //Провери дали енергията трябва да е 0
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energyLeft} energy");
                    isAlive = false;
                    break;
                }
                input = Console.ReadLine();
            }

            if (isAlive)
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energyLeft}");
            }
        }
    }
}
