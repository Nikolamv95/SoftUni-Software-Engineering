using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] watterInBotle = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queOfCups = new Queue<int>(cupCapacity);
            Stack<int> stackOfWatBot = new Stack<int>(watterInBotle);

            int wastedWater = 0;
            int currCupValue = 0;

            while (queOfCups.Count > 0 && stackOfWatBot.Count > 0)
            {
                int currCup = queOfCups.Peek() + currCupValue;
                int currBottle = stackOfWatBot.Peek();

                if (currBottle >= currCup)
                {
                    wastedWater += currBottle - currCup;
                    queOfCups.Dequeue();
                    stackOfWatBot.Pop();
                }
                else if (currCup > currBottle)
                {
                    stackOfWatBot.Pop();
                    currCupValue = currCup - currBottle;

                    while (currCupValue > 0)
                    {
                        currBottle = stackOfWatBot.Peek();

                        if (currBottle >= currCupValue)
                        {
                            wastedWater += currBottle - currCupValue;
                            currCupValue -= currBottle;
                            queOfCups.Dequeue();
                            stackOfWatBot.Pop();
                        }
                        else if (currCupValue > currBottle)
                        {
                            stackOfWatBot.Pop();
                            currCupValue -= currBottle;
                        }
                    }
                }
                currCupValue = 0;
            }

            if (queOfCups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', queOfCups)}");
            }
            if (stackOfWatBot.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', stackOfWatBot)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
