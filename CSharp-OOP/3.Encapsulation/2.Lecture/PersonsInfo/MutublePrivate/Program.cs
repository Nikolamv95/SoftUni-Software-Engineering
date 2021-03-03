using System;

namespace MutublePrivate
{
    class Program
    {
        static void Main(string[] args)
        {
            Human currHuman = new Human("ood", 16);
            Book curBook = currHuman.Book;

            currHuman.Book.Name = "toni"; // Не може да се изпълни защото данните се сетват само през конструктор при създаване на нов Human.

            Console.WriteLine(currHuman.Book.Name);
            Console.WriteLine(curBook.Page);
        }
    }
}
