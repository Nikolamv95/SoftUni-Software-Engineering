using Articles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles20
{
    class Program
    {
        static void Main(string[] args)
        {

            int lines = int.Parse(Console.ReadLine());
            List<Article> listOfArticle = new List<Article>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                             .Split(", ");

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article firstArticle = new Article(title, content, author);
                listOfArticle.Add(firstArticle);
            }


            string filterType = Console.ReadLine();

            switch (filterType)
            {
                case "title":
                    listOfArticle = listOfArticle.OrderBy(a => a.Title).ToList();
                    break;
                case "content":
                    listOfArticle = listOfArticle.OrderBy(a => a.Content).ToList();
                    break;
                case "author":
                    listOfArticle = listOfArticle.OrderBy(a => a.Author).ToList();
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, listOfArticle));   
        }

        class Article
        {

            public Article(string title, string content, string author)
            {

                Title = title;
                Content = content;
                Author = author;

            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
