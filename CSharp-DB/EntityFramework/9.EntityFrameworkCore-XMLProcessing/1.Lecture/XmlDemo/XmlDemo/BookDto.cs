using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlDemo
{
    [XmlType("book")]
    public class BookDTO
    {
        [XmlElement("author")]//Specifies the type’s name in XML

        public string Author { get; set; }

        [XmlElement("title")]//This is the name of the property in the xml.
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
