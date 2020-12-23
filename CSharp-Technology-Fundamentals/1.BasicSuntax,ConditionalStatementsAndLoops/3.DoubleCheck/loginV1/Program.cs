using System;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                char letter = userName[i];
                password += letter;
            }

            string passwordAtempt = Console.ReadLine();
            int wrongPassCount = 0;

            while (passwordAtempt != password)
            {
                wrongPassCount += 1;

                if (wrongPassCount == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }

                Console.WriteLine($"Incorrect password. Try again.");
                passwordAtempt = Console.ReadLine();
            }

            if (passwordAtempt == password)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
        }
    }
}
