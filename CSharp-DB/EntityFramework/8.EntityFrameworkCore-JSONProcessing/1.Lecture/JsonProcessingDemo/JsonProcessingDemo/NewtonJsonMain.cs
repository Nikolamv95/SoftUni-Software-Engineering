using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace JsonProcessingDemo
{
    public class Forecasts
    {
        public Tuple<int, string> AdditionalData { get; set; }
        public List<WeatherForecastNew> Forecast { get; set; }
    }

    public class WeatherForecastNew
    {
        //All properties should be public if we want JSON to read them

        // [JsonIgnore] //With this attributes JSON will ignore this property and will not read it
        public DateTime Date { get; set; } = DateTime.Now;

        // [JsonProperty("Temperature of the wether")] //This attribute changes the name of the curr property when JSON reads it
        public int[] TemperatureC { get; set; } = new[] { 30, 29, 199 };

        public string Summary { get; set; } = "Hot summer day.";
        public int Map { get; set; } = 123;
    }

    public class Employees
    {
        public string Username { get; set; }
    }

    public class NewtonJsonMain
    {
        static void Main()
        {
            var wether = new WeatherForecastNew();
            var employee = new Employees();

            //If we want additional settings of how to write the JSON
            //JsonOutputSettings(wether);

            ///Serialize object
            //SerializeObject(wether);

            ///Deserialize object
            //DeserializeObject();

            ///Formating JSON
            //FormatWithIndented();

            ///Formating to Annonymous object
            //AnnonymousObject();

            ///Work with JSON like dictionary
            //TakeValuesLikeDictionary();

            ///Convert from XML to JSON
            //XmlToJSON();

            ///Wor with csv
            //WorkWithCSV();
        }

        private static void WorkWithCSV()
        {
            using (CsvReader reader = new CsvReader
                (new StreamReader("Employee.csv"), CultureInfo.InvariantCulture))
            {
                var emp = reader.GetRecords<Employees>().ToList();
                foreach (var item in emp)
                {
                    Console.WriteLine(item.Username);
                }
            }
        }

        private static void XmlToJSON()
        {
            string xml =
                @"<?xml version='1.0' standalone='no'?> 
                 <root> 
                    <person id='1'> 
                        <name>Alan</name> 
                        <url>www.google.com</url> 
                    </person> 
                    <person id='2'> 
                        <name>Louis</name> 
                        <url>www.yahoo.com</url> 
                    </person> 
                </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Formatting.Indented);
            Console.WriteLine(jsonText);
        }

        private static void TakeValuesLikeDictionary()
        {
            var jsonDeser = File.ReadAllText("weather.json");
            JObject jObject = JObject.Parse(jsonDeser);
            Console.WriteLine(jObject["Summary"]);
        }

        private static void JsonOutputSettings(WeatherForecastNew wether)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                Culture = CultureInfo.InvariantCulture,
                NullValueHandling = NullValueHandling.Include,
                DateFormatString = "yyyy-MM-dd"
            };

            Console.WriteLine(JsonConvert.SerializeObject(wether, jsonSettings));
        }

        private static void AnnonymousObject()
        {
            //The names of the Annonymous should be similar to the name of the object properties
            var obj = new { Date = DateTime.UtcNow, Summary = string.Empty };
            var jsonDeser = File.ReadAllText("weather.json");
            obj = JsonConvert.DeserializeAnonymousType(jsonDeser, obj);
            Console.WriteLine(obj);
        }

        private static void DeserializeObject()
        {
            var jsonDeser = File.ReadAllText("weather.json");
            var wetherNew = JsonConvert.DeserializeObject<WeatherForecastNew>(jsonDeser);
            var summery = wetherNew.Summary;
            //Console.WriteLine(summery);
        }

        private static void SerializeObject(WeatherForecastNew wether)
        {
            var wetherJson = JsonConvert.SerializeObject(wether, Formatting.Indented);

            //Console.WriteLine(wetherJson);
            File.WriteAllText("weather.json", wetherJson);
        }

        private static void FormatWithIndented()
        {
            var forecast = new Forecasts
            {
                AdditionalData = new Tuple<int, string>(123, "Nikola"),
                Forecast = new List<WeatherForecastNew> { new WeatherForecastNew(), new WeatherForecastNew() }
            };
            var forercastJson = JsonConvert.SerializeObject(forecast, Formatting.Indented);

            Console.WriteLine(forercastJson);
        }
    }
}
