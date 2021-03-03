using System;
using System.Collections.Generic;
using System.Text;

namespace MutublePrivate
{
    class Book  
    {
        //За да направим така че сетването на данните за книгата да става само в класа Book, създаваме конструктор който приема
        //и записва данните, като сетърите са Private. Единствения начин да сетнеш книга е през конструктор при инстанцирането на класа
        //или такъв който е вързан за BOOK в случая Human ->
        public Book(string name, int page)
        {
            this.Name = name;
            this.Page = page;
        }

        public string Name { get; private set; }
        public int Page { get; private set; }
    }
}
