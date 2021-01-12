using System;
using System.Collections.Generic;
using System.Linq;

namespace articles20
{
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

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Article> listOfArticles = new List<Article>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);

                listOfArticles.Add(article);
            }

            string sorting = Console.ReadLine();

            List<Article> filteredList = new List<Article>();

            switch (sorting)
            {
                case "title":
                    filteredList = listOfArticles.OrderBy(t => t.Title).ToList();
                    break;
                case "content":
                    filteredList = listOfArticles.OrderBy(c => c.Content).ToList();
                    break;
                case "author":
                    filteredList = listOfArticles.OrderBy(a => a.Author).ToList();
                    break;
            }

            foreach (var item in filteredList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
