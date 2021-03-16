using System;
using System.IO;
using System.Text.Json;

namespace JsonProcessingDemo
{
    public class SystemTextJsonMain
    {
        public class WeatherForecast
        {
            public DateTime Date { get; set; } = DateTime.Now;
            public int TemperatureC { get; set; } = 30;
            public string Summery { get; set; } = "Hot summer day.";
        }

        static void WOrkWithJSON()
        {
            //Use using System.Text.Json

            ///Convert class to a JSON
            var weather = new WeatherForecast();
            var jsonSer = JsonSerializer.Serialize(weather);
            //File.WriteAllText("weather.json", jsonSer); //Save the JSON in file

            Console.WriteLine(jsonSer);//print on the console without settings

            //This is how we can do additional settings how to write the JSON on console
            Console.WriteLine(JsonSerializer.Serialize(weather, new JsonSerializerOptions
            {
                WriteIndented = true
            }));

            ///Convert JSON to class
            var jsonDeser = File.ReadAllText("weather.json");
            var weatherDeserialize = JsonSerializer.Deserialize<WeatherForecast>(jsonDeser);
            
            //DO something with weatherDeserialize
            var summery = weatherDeserialize.Summery;
            Console.WriteLine(summery);
        }
    }
}
