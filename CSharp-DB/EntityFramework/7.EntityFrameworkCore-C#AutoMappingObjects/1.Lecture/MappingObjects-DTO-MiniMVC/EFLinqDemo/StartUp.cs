using EFLinqDemo.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EFLinqDemo
{
    partial class StartUp
    {
        static void Main(string[] args)
        {
            //Layer 1 - This is the service wich receive the DB context (the data) and he is responsible to apply 
            //the LINQ operations on the DB
            //This layer thinks only how to connect the DBContext and the service with the logic inside
            //CONNECTION
            var service = new ArtistService(new MusicXContext());
            
            //Layer 2 - is the logic which we need which is called by the service
            //This layer is responsible only for the logic and the methods inside, he dont think about the connection
            //between the db and the service and how we will visualize the data on screen
            //LOGIC
            var artists = service.GetAllWithCount();

            //Layer 3 - This layer is called VIEW it has to visualize the data on screen
            //In this layer we think how to visualize the data ONLY. We dont care about the logic or the proccess itself
            //VISUALIZATION
            //  PrintService(artists);
            PrintArtistWithJSON(artists);
        }

        //View 2
        private static void PrintArtistWithJSON(IEnumerable<ArtistWithCount> artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented)); 
        }

        //View 1
        public static void PrintService(IEnumerable<ArtistWithCount> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine($"---{artist.Name} -- => {artist.SongsCount} song{(artist.SongsCount != 1 ? "s" : string.Empty)}");
            }
        }
    }
}
