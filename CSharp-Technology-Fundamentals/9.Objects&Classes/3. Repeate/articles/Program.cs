using System;
using System.Linq;

namespace articles
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

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
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

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                .ToArray();

            int numberChanges = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            for (int i = 0; i < numberChanges; i++)
            {
                string[] command = Console.ReadLine()
                                                   .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                                                   .ToArray();

                string operation = command[0];
                string text = command[1];

                switch (operation)
                {
                    case "Edit":
                        article.Edit(text);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(text);
                        break;
                    case "Rename":
                        article.Rename(text);
                        break;
                }
            }
            Console.WriteLine(article.ToString());
        }
    }
}
