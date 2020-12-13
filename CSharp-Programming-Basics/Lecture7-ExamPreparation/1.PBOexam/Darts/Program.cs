using System;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            int startPoints = 301;
            int sucShots = 0;
            int unSucShots = 0;
            bool isWinner = true;

            while (startPoints > 0)
            {
                string command = Console.ReadLine();

                if (command == "Retire")
                {
                    isWinner = false;
                    break;
                }

                int points = int.Parse(Console.ReadLine());
                
                switch (command)
                {
                    case "Single":
                        points *= 1;
                        break;
                    case "Double":
                        points *= 2;
                        break;
                    case "Triple":
                        points *= 3;
                        break;
                }

                if (points <= startPoints)
                {
                    startPoints -= points;
                    sucShots += 1;
                }
                else
                {
                    unSucShots += 1;
                }
            }

            if (isWinner == true)
            {
                Console.WriteLine($"{namePlayer} won the leg with {sucShots} shots.");
            }
            else
            {
                Console.WriteLine($"{namePlayer} retired after {unSucShots} unsuccessful shots.");
            }
            
        }
    }
}
