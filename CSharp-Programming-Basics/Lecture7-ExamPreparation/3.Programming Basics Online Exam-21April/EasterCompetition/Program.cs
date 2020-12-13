using System;

namespace EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaks = int.Parse(Console.ReadLine());
            string currBaker;
            string mark;
            int bestResult = 0;
            string bestBaker = string.Empty;

            for (int i = 0; i < numKozunaks; i++)
            {
                currBaker = Console.ReadLine();
                int currResult = 0;

                while ((mark = Console.ReadLine()) != "Stop")
                {
                    int data = int.Parse(mark);
                    currResult += data;
                }

                Console.WriteLine($"{currBaker} has {currResult} points.");

                if (currResult > bestResult)
                {
                    bestResult = currResult;
                    bestBaker = currBaker;
                    Console.WriteLine($"{currBaker} is the new number 1!");
                }
            }

            Console.WriteLine($"{bestBaker} won competition with {bestResult} points!");
        }
    }
}
