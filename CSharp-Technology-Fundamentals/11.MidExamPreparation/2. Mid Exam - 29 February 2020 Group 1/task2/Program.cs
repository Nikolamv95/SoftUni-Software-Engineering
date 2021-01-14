using System;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            int healthLeft = 100;
            int bitcoinsLeft = 0;
            bool isAlive = true;

            for (int i = 0; i < input.Length; i++)
            {
                string[] newInput = input[i]
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

                string command = newInput[0];
                int number = int.Parse(newInput[1]);

                switch (command)
                {
                    case "potion":
                        if (healthLeft + number > 100)
                        {
                            
                            int healdNum = number - ((healthLeft + number) - 100);
                            Console.WriteLine($"You healed for {healdNum} hp.");
                            healthLeft = 100;
                            Console.WriteLine($"Current health: {healthLeft} hp.");

                        }
                        else
                        {
                            healthLeft += number;
                            Console.WriteLine($"You healed for {number} hp.");
                            Console.WriteLine($"Current health: {healthLeft} hp.");
                        }
                        break;
                    case "chest":
                        bitcoinsLeft += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:

                        int attachHp = number;
                        string monster = command;

                        if (healthLeft > attachHp)
                        {
                            healthLeft -= attachHp;
                            Console.WriteLine($"You slayed {monster}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i+1}");
                            isAlive = false;
                        }
                        break;
                }

                if (!isAlive)
                {
                    break;
                }
            }

            if (isAlive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoinsLeft}");
                Console.WriteLine($"Health: {healthLeft}");
            }
        }
    }
}
