using AutoMapper;
using EFLinqDemo.Data;
using EFLinqDemo.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFLinqDemo
{
    class ExampleClass
    {
        //This class is like a NOTE transfered from StartUp
        public static void NewMain()
        {
            //Configuration of the AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistWithCount>();
                cfg.CreateMap<Song, SongViewModel>();
            });
            //This is the interface of the mapper whith which we are working on
            IMapper mapper = config.CreateMapper();

            //Context of the database
            var context = new MusicXContext();

            //Extract the values from the data which you want
            Artist artist = context.Artists.Where(x => x.Id == 10).FirstOrDefault();

            //The mapper check is there are similar propperties between Artist artist and ArtistWithCount artistViewModel
            //if there are similar properties the data will be writen in artistViewModel
            ArtistWithCount artistViewModel = mapper.Map<ArtistWithCount>(artist);

            PrintArtistWithJSON(artistViewModel);
        }

        //View
        private static void PrintArtistWithJSON(object artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented));
        }
    }
    

    
    

}

