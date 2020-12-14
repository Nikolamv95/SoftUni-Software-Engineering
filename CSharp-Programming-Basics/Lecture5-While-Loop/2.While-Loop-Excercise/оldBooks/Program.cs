using System;

namespace оldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputBook = Console.ReadLine();

            int readedBooks = 0;

            while (true)
            {
                string checkBook = Console.ReadLine();

                if (checkBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {readedBooks} books.");
                    Environment.Exit(0);
                }

                if (inputBook == checkBook)
                {
                    Console.WriteLine($"You checked {readedBooks} books and found it.");
                    Environment.Exit(0);
                }

                readedBooks += 1;
            }
        }
    }
}
