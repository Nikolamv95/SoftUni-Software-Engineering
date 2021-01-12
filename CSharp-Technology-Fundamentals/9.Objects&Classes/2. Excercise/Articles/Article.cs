using System;
using System.Collections.Generic;
using System.Text;

namespace Articles
{
    class Article
    {

        public Article (string title, string content, string author)
        {

            Title = title;
            Content = content;
            Author = author;

        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor (string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}"; 
        }
    }
}
