using System;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = String.Empty;

            for (int i = username.Length -1 ; i >= 0 ; i--)
            {
                char letter = username[i];
                password += letter;
            }

            string newPassword = Console.ReadLine();
            int counts = 0;

            while (newPassword != password)
            {
                counts += 1;
                
                if (counts >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine($"Incorrect password. Try again.");

                newPassword = Console.ReadLine();
            }

            if (newPassword == password)
            {
                Console.WriteLine($"User {username} logged in."); 
            }
        }
    }
}
