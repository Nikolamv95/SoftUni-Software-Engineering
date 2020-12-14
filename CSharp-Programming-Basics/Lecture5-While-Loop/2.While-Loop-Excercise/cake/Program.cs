using System;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtCake = int.Parse(Console.ReadLine());
            int heightCake = int.Parse(Console.ReadLine());

            int totalCake = lenghtCake * heightCake;
            int takenPeaces = 0;

            while (totalCake > 0)
            {
                string cakeForGuestText = Console.ReadLine();

                if (cakeForGuestText == "STOP")
                {
                    totalCake -= takenPeaces;
                    Console.WriteLine($"{totalCake} pieces are left.");
                    break;
                }

                int cakeForGuestNumber = Convert.ToInt32(cakeForGuestText);
                takenPeaces += cakeForGuestNumber;

                if (takenPeaces > totalCake)
                {
                    takenPeaces -= totalCake;
                    Console.WriteLine($"No more cake left! You need {takenPeaces} pieces more.");
                    Environment.Exit(0);
                }
            }
        }
    }
}
