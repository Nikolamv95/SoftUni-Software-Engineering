using System;
using System.Linq;

namespace task2
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

            for (int i = 0; i < liftSeats.Length; i++)
            {
                if (liftSeats[i] < 4)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (liftSeats[i] <= 4)
                        {
                            liftSeats[i] += 1;
                            peopleToEnter -= 1;

                            if (liftSeats[i] == 4)
                            {
                                break;
                            }

                            if (peopleToEnter == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            if (peopleToEnter == 0)
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
