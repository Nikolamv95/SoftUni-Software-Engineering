using System;

namespace EFLinqDemo
{
    //This is the mmapping object which connects the models and the view
    public class ArtistWithCount
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        //If the name of this property is similar to the name of property of the collection SongArtists in Artists
        //SongsCount become => SongArtists (we will have acces to the data inside) or SongArtistsCount (will count the number of songs inside)
        public int SongArtistsCount { get; set; }
    }
}