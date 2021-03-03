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

        public Library(params Book[] books)
        {
            this.books = books.ToList();
            this.books.Sort();
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
