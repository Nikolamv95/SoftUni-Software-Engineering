using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();

        //Влизайки в конструктура с данните които се съхраняват в params Book[] books
        //Данните ще се запишат в this.books = books.ToList() и след това ще се сортират
        //чрез this.books.Sort(new BookComparator())
        public Library(params Book[] books)
        {
            //1 - записване на книгите в books.ToList()
            this.books = books.ToList();
            //2 - Сортиране на книгите като се отиде в new BookComparator() и се изпълнят условията
            this.books.Sort(new BookComparator());
        }

        //yield return this.Books[i]; е съкратената версия на return new BooksEnumerator(Books);
        //public IEnumerator<Book> GetEnumerator()
        //{
        //   return new BooksEnumerator(Books);
        //}

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {   //С други думи yield return замества enumerator-a
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
