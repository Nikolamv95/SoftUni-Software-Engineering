namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var context = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //GetBooksByAgeRestriction(context, input);
            //GetGoldenBooks(context);
            //GetBooksByPrice(context);
            //GetBooksNotReleasedIn(context);
            //GetBooksByCategory(context);
            //GetBooksReleasedBefore(context);
            //GetAuthorNamesEndingIn(context);
            //GetBookTitlesContaining(context);
            //GetBooksByAuthor(context);
            //CountBooks(context);
            //CountCopiesByAuthor(context);
            //GetTotalProfitByCategory(context);
            //GetMostRecentBooks(context);
            //IncreasePrices(context);
            RemoveBooks(context);
        }

        private static void RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();
            int removedBooks = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            Console.WriteLine(removedBooks);
        }

        //Problem 15
        private static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 14
        private static void GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                            .Select(x => new
                            {
                                CategoryName = x.Name,
                                Top3Books = x.CategoryBooks
                                                        .Select(b => new
                                                        {
                                                            b.Book.Title,
                                                            b.Book.ReleaseDate
                                                        })
                                                        .OrderByDescending(b => b.ReleaseDate)
                                                        .Take(3)
                            })
                            .OrderBy(x => x.CategoryName)
                            .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine("--" + category.CategoryName);

                foreach (var item in category.Top3Books)
                {
                    sb.AppendLine($"{item.Title} ({item.ReleaseDate.Value.Year})");
                }
            }

            Console.WriteLine(sb);
        }

        //Problem 13
        private static void GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                            .Select(x => new
                            {
                                CategoryName = x.Name,
                                //We take the totalProfit when we select the whole Book entity and do aggregate function
                                //Sum(b=>b.Copies * b.Price) on it.
                                TotalProfit = x.CategoryBooks.Select(cd => cd.Book).Sum(b => b.Copies * b.Price)
                            })
                            .OrderByDescending(x => x.TotalProfit)
                            .ThenBy(x => x.CategoryName)
                            .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit}");
            }

            Console.WriteLine(sb);
        }

        //Problem 12
        private static void CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                        .Select(x => new
                        {
                            AuthorName = $"{x.FirstName} {x.LastName}",
                            NumberOfCopies = x.Books.Sum(x => x.Copies)
                        })
                        .OrderByDescending(x => x.NumberOfCopies)
                        .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.AuthorName} - {a.NumberOfCopies}");
            }

            Console.WriteLine(sb);
        }

        //Problem 11
        private static void CountBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            int titleLength = int.Parse(Console.ReadLine());

            var books = context.Books
                    .Where(x => x.Title.Length > titleLength)
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title)
                    .ToList();

            Console.WriteLine(books.Count());
        }

        //Problem 10
        private static void GetBooksByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            string letterSequence = Console.ReadLine();

            var authors = context.Authors
                    .Where(x => x.LastName.StartsWith(letterSequence))
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        Books = x.Books.Select(x => new
                        {
                            BookName = x.Title,
                            BookId = x.BookId
                        }),
                    })
                    .ToList();

            foreach (var author in authors)
            {
                foreach (var b in author.Books.OrderBy(x => x.BookId))
                {
                    sb.AppendLine($"{b.BookName} ({author.FirstName} {author.LastName})");
                }
            }

            Console.WriteLine(sb);
        }

        //Problem 09
        private static void GetBookTitlesContaining(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            string letterSequence = Console.ReadLine().ToLower();

            var books = context.Books
                    .Where(x => x.Title.ToLower().Contains(letterSequence))
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title)
                    .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b}");
            }

            Console.WriteLine(sb);
        }

        //Problem 08
        private static void GetAuthorNamesEndingIn(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            string letterSequence = Console.ReadLine();

            var authors = context.Authors
                    .Where(x => x.FirstName.EndsWith(letterSequence))
                    .Select(x => new { x.FirstName, x.LastName })
                    .OrderBy(x => x.FirstName)
                    .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName}");
            }

            Console.WriteLine(sb);
        }

        //Problem 07
        private static void GetBooksReleasedBefore(BookShopContext context)
        {

            StringBuilder sb = new StringBuilder();

            string[] dateParts = Console.ReadLine()
                                .Split('-', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            var day = int.Parse(dateParts[0]);
            var month = int.Parse(dateParts[1]);
            var year = int.Parse(dateParts[2]);

            var givenDate = new DateTime(year, month, day);

            var books = context.Books
                .Where(x => x.ReleaseDate < givenDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new { Title = x.Title, Type = x.EditionType.ToString(), Price = x.Price })
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.Type} - ${b.Price}");
            }

            Console.WriteLine(sb);
        }

        //Problem 06
        private static void GetBooksByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> booksToPrint = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string category = input[i];

                var books = context.BooksCategories
                                .Where(x => x.Category.Name == category)
                                .Select(x => new { BookTitle = x.Book.Title })
                                .ToList();

                foreach (var b in books)
                {
                    booksToPrint.Add(b.BookTitle);
                }
            }

            foreach (var tittle in booksToPrint.OrderBy(x => x))
            {
                sb.AppendLine(tittle);
            }

            Console.WriteLine(sb);
        }

        //Problem 05
        private static void GetBooksNotReleasedIn(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            int year = int.Parse(Console.ReadLine());

            var books = context.Books
                        .Where(x => x.ReleaseDate.Value.Year != year)
                        .OrderBy(x => x.BookId)
                        .Select(x => x.Title)
                        .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b}");
            }

            Console.WriteLine(sb);
        }

        //Problem 04
        private static void GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                    .Where(x => x.Price > 40)
                    .Select(x => new { x.Title, x.Price })
                    .OrderByDescending(x => x.Price)
                    .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price}");
            }

            Console.WriteLine(sb);
        }

        //Problem 03
        private static void GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                        .Where(x => x.EditionType == EditionType.Gold)
                        .Where(c => c.Copies < 5000)
                        .OrderBy(x => x.BookId)
                        .Select(x => new { Title = x.Title })
                        .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            Console.WriteLine(sb);
        }

        //Problem 02
        private static void GetBooksByAgeRestriction(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();

            var books = context.Books
                        .AsEnumerable()
                        .Where(x => x.AgeRestriction.ToString().ToLower() == input.ToLower())
                        .Select(x => new { Title = x.Title })
                        .OrderBy(x => x.Title)
                        .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            Console.WriteLine(sb);
        }
    }
}
