using EFLinqDemo.Data;
using System.Collections.Generic;
using System.Linq;

namespace EFLinqDemo
{
    //This is the Interface which containce the needed methods
    interface IArtistService
    {
        IEnumerable<ArtistWithCount> GetAllWithCount();
    }

    //This is the Service class which works with Artist entity and do a logic with it
    class ArtistService : IArtistService
    {
        private readonly MusicXContext context;

        //Intialize the context
        public ArtistService(MusicXContext context)
        {
            this.context = context;
        }

        //Do logic and return an object or IEnumerable of artist
        public IEnumerable<ArtistWithCount> GetAllWithCount()
        {
            var artist = this.context.Artists
                            .Select(x => new ArtistWithCount
                            {
                                Name = x.Name,
                                SongsCount = x.SongArtists.Count()
                            })
                            .ToList();

            return artist;
        }
    }

}
