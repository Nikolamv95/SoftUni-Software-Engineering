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
            Console.WriteLine(password);
        }
    }
}
