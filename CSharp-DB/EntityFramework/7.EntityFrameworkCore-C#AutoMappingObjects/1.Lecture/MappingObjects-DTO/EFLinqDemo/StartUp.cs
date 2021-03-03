using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFLinqDemo.Data;
using EFLinqDemo.Data.Models;
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
            //var config = new MapperConfiguration(cfg =>
            //{
            //    //This config maps Artist and ArtistWithCount.
            //    cfg.CreateMap<Artist, ArtistWithCount>();

            //    //This config maps Song and SongViewModel and setup custom logic for how to print on of the SongViewModel Artists
            //    cfg.CreateMap<Song, SongViewModel>()
            //        .ForMember(x=> x.Artists, 
            //                   opt => opt.MapFrom(x=> string.Join(", ", x.SongArtists.Select(y=> y.Artist.Name))));
            //});

            //var context = new MusicXContext();

            //var songViewModel = context.Songs.ProjectTo<SongViewModel>(config).Take(10);

            //PrintArtistWithJSON(songViewModel);







            // With reverse map we convert random classes into a real DB objects
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistWithCount>();

                cfg.CreateMap<Song, SongViewModel>()
                    .ForMember(x => x.Artists,
                               opt => opt.MapFrom(x => string.Join(", ", x.SongArtists.Select(y => y.Artist.Name))))
                    .ReverseMap();
            });
            
            var mapper = config.CreateMapper();

            var context = new MusicXContext();

            var inputModel = new SongViewModel
            {
                Name = "Test123",
                SourceName = "Vbox7",
            };

            var song = mapper.Map<Song>(inputModel);

            PrintArtistWithJSON(song);

            context.Songs.Add(song);
            context.SaveChanges();
        }

        //View
        private static void PrintArtistWithJSON(object model)
        { 
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented)); 
        }
    }
}
