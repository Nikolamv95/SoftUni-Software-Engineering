using System;
using System.Linq;

namespace task2v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleToEnter = int.Parse(Console.ReadLine());
            int[] liftSeats = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            bool isFinished = false;

                for (int i = 0; i < liftSeats.Length; i++)
                {
                    while (liftSeats[i] < 4)
                    {
                        if (liftSeats[i] == 3)
                        {
                            liftSeats[i] += 1;
                            peopleToEnter -= 1;
                        }

                        else
                        {
                            liftSeats[i] += 1;
                            peopleToEnter -= 1;                          
                        }

                        if (peopleToEnter == 0)
                        {
                            isFinished = true;
                            break;
                        }
                    }

                    if (isFinished == true)
                    {
                        break;
                    }
                }

            if (isFinished == true)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(' ', liftSeats));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {peopleToEnter} people in a queue!");
                Console.WriteLine(string.Join(' ', liftSeats));
            }
        }
    }
}
