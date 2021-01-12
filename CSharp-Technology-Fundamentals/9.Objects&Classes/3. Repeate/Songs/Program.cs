using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            List<Song> listOfSongs = new List<Song>();

            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split('_').ToArray();

                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name= name;
                song.Time = time;

                listOfSongs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var song in listOfSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in listOfSongs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
