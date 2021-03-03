using System.Collections.Generic;
using System.Linq;
using System;

namespace IComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            var list = MergeList(bookOne, bookTwo, bookThree);

            //Compare by year
            list.Sort(new BooksComparer());

            foreach (var item in list)
            {
                Console.WriteLine(item.Title + item.Year);
            }
            Console.WriteLine("------------------------------");
            //Compare by title
            list.Sort(new BooksComparerName());
            foreach (var item in list)
            {
                Console.WriteLine(item.Title + item.Year);
            }

        }

        
        static List<T> MergeList<T>(params T[] books)
        {
            return books.ToList();
        }
    }
}
