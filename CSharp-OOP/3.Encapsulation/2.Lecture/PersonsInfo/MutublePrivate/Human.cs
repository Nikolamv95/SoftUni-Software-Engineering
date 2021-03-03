using System;
using System.Collections.Generic;
using System.Text;

namespace MutublePrivate
{
    class Human
    {
        //Тук логиката е същата, създаваме пропърти от Book което е Private и отново се сетва само чрез конструктор.
        //Подавайки данните на конструктора той създава нова книга, връща се в класа Book и записва данните, след това се връща 
        //и записва текущата книга в пропъртито book. Така в класа Program един път сетнат ли се данните после не могат да бъдат променяни
        private Book book;
        public Human(string name, int page)
        {
            this.book = new Book(name, page);
        }

        public Book Book
        {
            get
            {
                return this.book;
            }
        }
    }
}
