using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Author = "Svetlin Nakov",
                    Title = "Programming Basics",
                    Genre = "Drama",
                    Price = 1000m,
                    PublishDate = DateTime.UtcNow,
                    Description = "The best book ever"
                },
                new Book
                {
                    Author = "Svetlin Nakov Two",
                    Title = "Programming Basics 2",
                    Genre = "Drama 2",
                    Price = 1032m,
                    PublishDate = DateTime.UtcNow,
                    Description = "The best boock ever ever"
                },
            };

            XmlSerializer serializeObject = 
                        new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("CustomBooks"));

            serializeObject.Serialize(File.OpenWrite("BooksImported.xml"), books);

        }

        private static void DeserializeXml()
        {
            //Variation 1 without XmlCOnverter Class
            //XmlSerializer serializer = new XmlSerializer(typeof(BookDTO[]),
            //    new XmlRootAttribute("Books"));

            //var deserializedBook = (BookDTO[]) serializer
            //    .Deserialize(File.OpenRead("Books.xml"));

            //Variation 2 with XmlCOnverter Class
            string rootElement = "Books";
            string inputXml = File.ReadAllText("Books.xml");
            var booksDTOs = XmlConverter.Deserializer<BookDTO>(inputXml, rootElement).ToList();

            foreach (var item in booksDTOs)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void CreateXmlFileWithDataInside()
        {
            XDocument xmlDoc = new XDocument();
            xmlDoc.Add(
                new XElement("books",
                    new XElement("book",
                        new XElement("author", "Don Box"),
                        new XElement("title", "ASP.NET", new XAttribute("lang", "en"))
                    )));

            xmlDoc.Save("myBooks.xml");
        }

        private static void WorkWithXmlAndLinq()
        {
            XDocument xmlDocument = XDocument.Load("Books.xml");

            var articles = xmlDocument.Root
                .Elements()
                .Where(x => x.Element("author").Value.Contains("Corets, Eva"))
                .OrderBy(x => x.Element("title").Value)
                .Select(x => new
                {
                    Author = x.Element("author").Value,
                    Title = x.Element("title").Value,
                    Genre = x.Element("genre").Value,
                    Price = x.Element("price").Value,
                }).ToList();

            foreach (var ar in articles)
            {
                Console.WriteLine($"{ar.Author} - {ar.Title} - {ar.Title} - {ar.Price}");
            }
        }

        private static void LoadXMLFiles()
        {
            //Read xml from a file
            XDocument xml = XDocument.Load("Planes.xml");
            Console.WriteLine(xml);

            XDocument xmlDocumentNew = XDocument.Load("Planes.xml");
            Console.WriteLine(xmlDocumentNew.Declaration.Encoding);
            Console.WriteLine(xmlDocumentNew.Root.Elements().Count());
            Console.WriteLine(xmlDocumentNew.Root.Elements()
                .FirstOrDefault(x => x.Element("color").Value == "Blue").Element("year").Value);
        }

        private static void AccessAttributesAndValues(XDocument xmlDocument)
        {
            //XDocument xmlDocument = XDocument.Load("Books.xml");

            foreach (var book in xmlDocument.Root.Elements())
            {
                //<author - (this is the attribute)> Corets, Eva </author>
                book.Element("title").SetAttributeValue("lang", "bg");
                //this is how we access the attribute

                //<author> Corets, Eva (this is the value) </author>
                book.SetElementValue("description", null);
                //this is how we access the value
            }

            xmlDocument.Save("books_updated.xml");
        }
    }
}
