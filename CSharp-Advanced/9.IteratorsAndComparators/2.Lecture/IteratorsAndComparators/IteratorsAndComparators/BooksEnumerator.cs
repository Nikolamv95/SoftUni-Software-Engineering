using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BooksEnumerator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currIndex = -1;

        public BooksEnumerator()
        {
            this.books = new List<Book>();
        }

        public BooksEnumerator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => books[currIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            currIndex++;
            return currIndex < books.Count;
        }

        public void Reset()
        {
            currIndex -= 1;
        }
    }
}
