using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlDemo
{
    public class Book
    {
        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("price")]
        public Decimal Price { get; set; }

        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
    }
}
