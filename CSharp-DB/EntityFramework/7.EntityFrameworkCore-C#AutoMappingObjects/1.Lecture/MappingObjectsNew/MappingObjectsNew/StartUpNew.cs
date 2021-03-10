using AutoMapper;
using AutoMapper.QueryableExtensions;
using MappingObjectsNew.Model;
using MappingObjectsNew.Model.Data;
using MappingObjectsNew.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MappingObjectsNew
{
    class StartUpNew
    {
        static void MethodAsManin(string[] args)
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
    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile(new ArtistWithCountProfileProfile());
    //            cfg.AddProfile(new SongsToViewModelProfile());
                
    //        });

    //        var mapper = config.CreateMapper();

    //        var context = new MusicXContext();
    //        var songs = context.Songs.ProjectTo<SongViewModel>(config).Take(10).ToList();

    //        PrintArtistWithJSON(songs);
    //    }

    //    //View
    //    private static void PrintArtistWithJSON(object model)
    //    {
    //        Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
    //    }
    //}
}
