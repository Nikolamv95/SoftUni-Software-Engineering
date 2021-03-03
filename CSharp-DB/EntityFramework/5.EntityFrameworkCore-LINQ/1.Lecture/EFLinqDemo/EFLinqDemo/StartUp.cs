using EFLinqDemo.Data;
using EFLinqDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.EntityFramework.Plus;

namespace EFLinqDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.Unicode;
            var context = new MusicXContext();

            //NestedSelectPlusCreatingClass(context);
            //UseAnnonomousModel(context);
            //AggregateFunctionsToUse(context);
            //WorkWithGroupBy(context);
            //WorkWithSelectMany(context);
            
            //WorkWIthSQLQueries(context);
            //ExtractObjectAndTrackingInfo(context);
            
            //BulkDelete(context);
            //BulkUpdate(context);
            
            //TypesOfLoadingLazyEagerExplicitSelect(context);
            
            //ConcurrencyCheckFlow();
        }

        private static void ConcurrencyCheckFlow()
        {
            //Concurency
            //In this case only the contex2.SaveChanges will save its result and the final result will be "Осъдени души2"
            var context = new MusicXContext();
            var song = context.Songs.Where(x => x.Name.StartsWith("Осъдени души")).FirstOrDefault();
            song.Name = song.Name + "1";


            var context2 = new MusicXContext();
            var song2 = context2.Songs.Where(x => x.Name.StartsWith("Осъдени души")).FirstOrDefault();
            song2.Name = song2.Name + "2";

            //context.SaveChanges();
            //context2.SaveChanges(); with [ConcurrencyCqheck] will throw an exception


            //If we put over the Name property [ConcurrencyCqheck] the program will save context.SaveChanges the result will
            //be "Осъдени души1" and context2 will throw an exception because the name is not anymore "Осъдени души".
            var context3 = new MusicXContext();
            var song3 = context3.Songs.Where(x => x.Name.StartsWith("Осъдени души")).FirstOrDefault();
            song3.Name = song3.Name + "1";


            var context4 = new MusicXContext();
            var song4 = context4.Songs.Where(x => x.Name.StartsWith("Осъдени души")).FirstOrDefault();
            song4.Name = song4.Name + "2";

            context3.SaveChanges();

            //We handle the exception and do ...... something
            try
            {
                context4.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                var context5 = new MusicXContext();
                var song5 = context5.Songs.Where(x => x.Name.StartsWith("Осъдени души")).FirstOrDefault();
                song5.Name = song5.Name + "2";

                context5.SaveChanges();
            }
        }

        //Loadings Start
        private static void TypesOfLoadingLazyEagerExplicitSelect(MusicXContext context)
        {
            //Advice take the data from second leve table with proection (table.Select(......)) 
            //dont use Lazy Loading or the other types of loading USE SELECT(x=> new object{data})

            //NotWorkingCase(context);
            //ProectionLoadingSelectBest(context);
            //ExplicitLoading(context);
            //EagerLoading(context);
            //LazyLoading(context);
        }
        private static void NotWorkingCase(MusicXContext context)
        {
            //In this case we dont have access to Source.Name
            var song = context.Songs
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            //Console.WriteLine(song.Name);
            //Console.WriteLine(song.Source.Name);
        }
        private static void LazyLoading(MusicXContext context)
        {
            //Variation 4 -> LazyLoading
            //Instal Microsoft.EntityFrameworkCore.Proxies
            //Add to the optionsBuilder.UseSqlServer("Server=DESKTOP-0J5UCH7\\SQLEXPRESS;Database=MusicX;
            //Security=true;").UseLazyLoadingProxies()
            //All relationship properties and ICollections have to be virtual

            //WE try to not use it -> slower our code performance.
            var song5 = context.Songs
                .Where(x => x.Name.Contains("а") || x.Name.Contains("Е"))
                .ToList();

            foreach (var s in song5)
            {
                Console.WriteLine($"{s.Name}");
                Console.WriteLine($"{s.Source.Name}");

                foreach (var e in s.SongMetadata)
                {
                    Console.WriteLine(e.CreatedOn);
                }
            }

        }
        private static void EagerLoading(MusicXContext context)
        {
            //Variation 3 is Eager Loading. It works only with cases when we extract list of objects
            //ToListr(), ToArray() etc....
            //We use it if we want to do CRUD Operations
            var song4 = context.Songs
                .Include(x => x.Source)//which data we need to be loaded
                .Include(x => x.SongMetadata)//which data we need to be loaded
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            Console.WriteLine(song4.Name);
            Console.WriteLine(song4.Source?.Name);//If we dont have data will return null ?

            foreach (var item in song4.SongMetadata)
            {
                Console.WriteLine(item.CreatedOn);
            }
        }
        private static void ExplicitLoading(MusicXContext context)
        {
            //Variation 2 is Explicit Loading. It works only with cases when we extract only 1 object
            //Single, FirstOrDefault etc....
            var song3 = context.Songs
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            context.Entry(song3).Reference(x => x.Source).Load();// If we want to load a property
            context.Entry(song3).Collection(x => x.SongMetadata).Load();// If we want to load a collection

            Console.WriteLine(song3.Name);
            Console.WriteLine(song3.Source?.Name); //If we dont have data will return null ?

            foreach (var item in song3.SongMetadata)
            {
                Console.WriteLine(item.CreatedOn);
            }
        }
        private static void ProectionLoadingSelectBest(MusicXContext context)
        {
            //Variation 1 to have access is with proection -> Select
            //WE CANNOT DO CRUD Opperations
            var song2 = context.Songs
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .Select(x => new { x.Name, SourceName = x.Source.Name, CreatedOn = x.SongMetadata.Select(c => c.CreatedOn) })
                .FirstOrDefault();

            Console.WriteLine(song2.Name);
            Console.WriteLine(song2.SourceName);

            foreach (var item in song2.CreatedOn)
            {
                Console.WriteLine(item);
            }
        }


        //Library -> Z.EntityFramework.Plus Start
        private static void BulkUpdate(MusicXContext context)
        {
            //Library -> Z.EntityFramework.Plus Update
            context.Songs//choose which object you want to update
                .Where(x => x.Name.Contains("а") || x.Name.Contains("е"))//filter the objects which you want
                .Update(song => new Song { Name = song.Name + " (BG)" });//Do the changes

            //SELECT * FROM Songs
            //WHERE Name LIKE N'%а%' OR Name LIKE N'%е%'
        }
        private static void BulkDelete(MusicXContext context)
        {
            //Library -> Z.EntityFramework.Plus Delete
            context.SongMetadata.Where(x => x.Id <= 10).Delete();
        }


        //WorkWith SQL Queries
        private static void ExtractObjectAndTrackingInfo(MusicXContext context)
        {
            var currSongName = Console.ReadLine();
            var song = context.Songs.FirstOrDefault(x => x.Name == $"{currSongName}");

            var currSongNewName = Console.ReadLine();
            song.Name = $"{currSongNewName}";

            //.AsNoTracking(), context.Entry(song).State = EntityState.Detached, or 
            //receiving objcet from another instance of the DB context (var contextDB = new MusicXContext()
            //will not be tracked from the current context (var context = new MusicXContext()))
        }
        private static void WorkWIthSQLQueries(MusicXContext context)
        {
            //Work with SQL queries with SQL Injection
            var searchString = Console.ReadLine(); //%_bv%

            //Extract data
            var songs = context.Songs.FromSqlInterpolated($"SELECT * FROM [Songs] WHERE [Name] LIKE {searchString}").ToList();
            var songs2 = context.Songs.FromSqlRaw("SELECT * FROM [Songs] WHERE [Name] LIKE {0}", searchString).ToList();

            foreach (var s in songs)
            {
                Console.WriteLine($"{s.Name} ");
            }

            Console.WriteLine("------------------");

            foreach (var s in songs2)
            {
                Console.WriteLine($"{s.Name} ");
            }

            //CRUD Operations -> Will not return value
            context.Database.ExecuteSqlInterpolated($"DELETE.......... code");
        }
        

        //Work with Functions
        private static void UseAnnonomousModel(MusicXContext context)
        {
            //Annonomous Model
            var songsAnn = context.Songs
                .Where(x => x.SongArtists.Count() > 2)
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => new
                {
                    Name = x.Name,
                    AllArtists = x.SongArtists.Select(a => a.Artist.Name),
                    FirstArtist = x.SongArtists.Select(a => a.Artist.Name).Min()
                })
                .Take(10)
                .ToList();
        }
        private static void WorkWithSelectMany(MusicXContext context)
        {
            //Work with selectMany -> takes all songs from all Authors
            var topSongs = context.Artists
                .Where(a => a.Name.StartsWith("Z"))
                .SelectMany(x => x.SongArtists.Select(n => n.Song.Name))
                .Take(10)
                .ToList();

            foreach (var s in topSongs)
            {
                Console.WriteLine($"{s}");
            }
        }
        private static void WorkWithGroupBy(MusicXContext context)
        {
            //Work with group by
            var songGroups = context.Songs
                    .GroupBy(x => x.Name.Substring(0, 1))
                    .Select(x => new
                    {
                        FirstLetter = x.Key,
                        Count = x.Count(),
                        First = x.Min(x => x.Name)
                    })
                    .Take(10)
                    .ToList();

            foreach (var s in songGroups)
            {
                Console.WriteLine($"{s.FirstLetter} -> Count -> {s.Count} -> First Artist -> {s.First}");
            }
        }
        private static void AggregateFunctionsToUse(MusicXContext context)
        {
            var newSong = context.Songs
                            .Where(x => x.SongArtists.Count() > 2)
                            .Max(x => x.Name);

            Console.WriteLine(newSong);
        }
        private static void NestedSelectPlusCreatingClass(MusicXContext context)
        {
            var songs = context.Songs
                .Where(x => x.SongArtists.Count() > 2)  // 1 - Filter
                .OrderBy(x => x.Name) // 2 - Order 1
                .ThenBy(x => x.Id) // 3 - Oredr 2
                .Select(x => new ViewArtistInfo(
                            x.Name,
                            x.SongArtists.Select(a => a.Artist.Name),
                            x.SongArtists.Select(a => a.Artist.Name).Min()
                        )) // 4 - Extract only the data which is needed
                .Take(10) // 5 Amount of values to take
                .ToList(); // 6 transform to IEnumberable. All changes will not be saved to the REAL DB,
                           // if it`s without .ToList the collection will be Iqueryable and then we can 
                           // do changes in the real DB with context.SaveChanges() at the end.

            foreach (var song in songs)
            {
                Console.WriteLine($"{string.Join(", ", song.Artist)} -> made -> {song.Name} -> First Artist -> {song.FirstArtist}");
            }
        }
    }

    internal class ViewArtistInfo
    {
        public ViewArtistInfo(string name, IEnumerable<string> artist, string firstArtist)
        {
            Name = name;
            Artist = artist;
            FirstArtist = firstArtist;
        }

        public string Name { get; set; }
        public IEnumerable<string> Artist { get; set; }
        public string FirstArtist { get; set; }
    }
}
