using System;

namespace Indexator
{
    class Program
    {
        //Така се създава индексатор който после може да се ползва да се чете масива
        static void Main(string[] args)
        {
            Book book = new Book();
            Console.WriteLine(book[0]);
        }

        class Book
        {
             private string[] pages = new string[]
             {
                 "page 1",
                 "page 2",
                 "page 3",
                 "page 4",
                 "page 5",
             };

            public string this[int i]
            {
                get { return pages[i]; }
            }
        }
    }
}
