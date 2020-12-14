using System;

namespace walking
{
    class Program
    {
        static void Main(string[] args)
        {

            int walkingGoal = 10000;
            int stepsCounter = 0;

            while (walkingGoal > stepsCounter)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    int finalSteps = int.Parse(Console.ReadLine());
                    stepsCounter += finalSteps;

                    if (walkingGoal > stepsCounter)
                    {
                        walkingGoal -= stepsCounter;
                        Console.WriteLine($"{walkingGoal} more steps to reach goal.");
                        Environment.Exit(0);
                    }
                    break;
                }
                int stepsToWalk = Convert.ToInt32(input);
                stepsCounter += stepsToWalk;
            }

            if (stepsCounter > walkingGoal)
            {
                stepsCounter -= walkingGoal;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCounter} steps over the goal!");
            }

        }
    }
}
