using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfGroups = int.Parse(Console.ReadLine());
            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;
            int totalPeople = 0;

            for (int i = 0; i < numOfGroups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                totalPeople += peopleInGroup;

                if (peopleInGroup <= 5)
                {
                    musala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monblan += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest += peopleInGroup;
                }
            }
        }
    }
}
