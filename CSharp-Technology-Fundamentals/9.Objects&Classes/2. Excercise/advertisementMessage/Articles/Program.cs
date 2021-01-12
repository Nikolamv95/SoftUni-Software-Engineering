using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                             .Split(", ");

            int lines = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article firstArticle = new Article(title,content,author);


            for (int i = 0; i < lines; i++)
            {
                string[] commands = Console.ReadLine()
                                     .Split(": ");

                string newText = commands[1];

                if (commands[0] == "Edit")
                {
                    firstArticle.Edit(newText);
                }
                else if (commands[0] == "ChangeAuthor")
                {
                    firstArticle.ChangeAuthor(newText);
                }
                else if (commands[0] == "Rename")
                {
                    firstArticle.Rename(newText);
                }
            }

            Console.WriteLine(firstArticle.ToString());
        }
    }
}