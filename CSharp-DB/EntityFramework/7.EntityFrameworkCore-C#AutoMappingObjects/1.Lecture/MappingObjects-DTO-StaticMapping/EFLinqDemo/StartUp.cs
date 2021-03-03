using EFLinqDemo.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFLinqDemo
{
    partial class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MusicXContext();

            //In this case artistWithCount.SongsCount = artist.SongArtists.Count(); will fill the property with 0

            //var artist = context.Artists.FirstOrDefault();
            //var artistWithCount = new ArtistWithCount();

            //artistWithCount.Name = artist.Name;
            //artistWithCount.SongsCount = artist.SongArtists.Count();

            //PrintArtistWithJSON(artistWithCount);

            //So the right code in this situation is:

            //ArtistWithCount is the mapping class and will SongsCount will be saved the value from
            //x.SongArtists.Count()
            var artist = context.Artists.Select(x => new ArtistWithCount
            {
                Name = x.Name,
                SongsCount = x.SongArtists.Count()
            }).FirstOrDefault();

            PrintArtistWithJSON(artist);
        }

        //View 2
        private static void PrintArtistWithJSON(object artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented)); 
        }
    }
}
