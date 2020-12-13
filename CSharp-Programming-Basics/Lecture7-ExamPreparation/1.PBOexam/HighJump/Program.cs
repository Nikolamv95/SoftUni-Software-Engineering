using System;

namespace HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedLength = int.Parse(Console.ReadLine());
            int startLength = wantedLength - 30;
            int currLenght = 0;
            int unsuccAttempt = 0;
            int totalAttempt = 0;
            bool isUnsucessfull = false;

            while (startLength <= wantedLength)
            {
                int input = int.Parse(Console.ReadLine());

                totalAttempt += 1;

                if (input > startLength)
                {
                    startLength += 5;
                    currLenght = input;
                    unsuccAttempt = 0;
                }
                else
                {
                    unsuccAttempt += 1;

                    if (unsuccAttempt == 3)
                    {
                        isUnsucessfull = true;
                        break;
                    }
                }
            }

            if (isUnsucessfull == false)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {wantedLength}cm after {totalAttempt} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir failed at {startLength}cm after {totalAttempt} jumps.");
            }
        }
    }
}
