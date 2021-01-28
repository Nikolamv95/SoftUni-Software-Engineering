using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ").ToArray();
            Queue<string> queOfSongs = new Queue<string>(songsInput);

            while (queOfSongs.Count > 0)
            {
                string command = Console.ReadLine();

                string operation = command.Substring(0, 4);

                switch (operation)
                {
                    case "Play":
                        queOfSongs.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queOfSongs));
                        break;
                    case "Add ":
                        string song = command.Substring(4);

                        if (queOfSongs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queOfSongs.Enqueue(song);
                        }
                        break;
                }
            }

            if (queOfSongs.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
