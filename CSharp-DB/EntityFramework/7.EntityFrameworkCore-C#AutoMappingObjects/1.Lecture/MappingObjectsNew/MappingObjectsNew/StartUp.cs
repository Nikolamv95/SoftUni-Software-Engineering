using AutoMapper.QueryableExtensions;
using MappingObjectsNew.Model;
using MappingObjectsNew.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MappingObjectsNew
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MusicXContext();
            var songs = context.Songs.ProjectTo<SongViewModel>(config).Take(10).ToList();

            PrintArtistWithJSON(songs);
        }

        //View
        private static void PrintArtistWithJSON(object model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }
    }
}
