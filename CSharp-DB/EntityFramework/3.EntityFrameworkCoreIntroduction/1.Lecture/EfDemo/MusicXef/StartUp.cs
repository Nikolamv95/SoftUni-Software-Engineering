using Microsoft.EntityFrameworkCore;
using MusicXef.Models;
using System;
using System.Linq;

namespace MusicXef
{
    class StartUp
    {   //ModelFirst approach
        static void Main(string[] args)
        {
            // public DateTime? ModifiedOn { get; set; } -> this ? give us the chance to set DateTime as a null. We can use that for all
            //data types which are value type like (int, double, DateTime and etc). put ? after the data type int? and we can set this value as null.


            //This is how we can control the login to database which we want. It`s not nesseccery at this time
            //because the MusicXContext has such a method OnConfiguring

            //var optionsBuilder = new DbContextOptionsBuilder<MusicXContext>();
            //optionsBuilder.UseSqlServer("Server=DESKTOP-0J5UCH7\\SQLEXPRESS;Database=MusicXCopy;Integrated Security=true;");
            //var dbNew = new MusicXContext(optionsBuilder.Options);
            //dbNew.Database.EnsureCreated(); -> will check the is Database=MusicX exist and if not will create it with the structure which we have now in c#
            //If has it will skip. This is how we can copy a database MusicX => MusicXCopy with all assets inside. 
            //In databse we have 2 similr BD`s MusicX and MusicXCopy


            var db = new MusicXContext();
            Console.WriteLine(db.Songs.Count(x => x.SongArtists.Count() > 1));

            Console.WriteLine();
            Console.WriteLine("NewExampleeeeee");
            Console.WriteLine();

            var artists = db.Artists.Select(x => new
            {
                ArtistName = x.Name,
                NumOfSongs = x.SongArtists.Count()
            }).OrderByDescending(x => x.NumOfSongs).Take(10).ToList();

            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.ArtistName} has {artist.NumOfSongs} songs.");
            }


            Console.WriteLine();
            Console.WriteLine("NewExampleeeeee");
            Console.WriteLine();

            var artistsA = db.Artists.Select(x => new
            {
                ArtistName = x.Name,
                CountSongsA = x.SongArtists.Count(x => x.Song.Name.StartsWith("A")),
                NumOfSongs = x.SongArtists.Count()
            }).OrderByDescending(x => x.NumOfSongs).ThenBy(x => x.CountSongsA).Take(10).ToList();

            foreach (var artist in artistsA)
            {
                Console.WriteLine($"{artist.ArtistName} has {artist.NumOfSongs} songs which {artist.CountSongsA} starts with A.");
            }

        }
    }
}
