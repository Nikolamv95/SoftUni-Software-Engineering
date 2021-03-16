using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUserSoldProductDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        //If you have nested array in the xml use for attribute XmlArray in order to have the following structure
        //<soldProducts>
            //<Product>
                //<attribute>data</attribute>
        [XmlArray("soldProducts")]
        public List<UserProductDto> ProductsList { get; set; }
    }


    [XmlType("Product")]
    public class UserProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
