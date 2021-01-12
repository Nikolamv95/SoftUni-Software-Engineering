using System;
using System.Collections.Generic;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - Дефинираме колко песни ще въведем
            int numsSongs = int.Parse(Console.ReadLine());
            //Стъпка 2-> Виж Songs.cs

            //Стъпка 3 създаваме " List listOfSongs " като типа на този List
            //е нашия нов клас <Songs>. Оставяме листа без упозначена големина
            List<Song> listOfSongs = new List<Song>();
            
            //Стъпка 4 създаваме цикъл с който ще преминем Х пъти през него
            //за да вземем и запишен Input данните ни
            for (int i = 0; i < numsSongs; i++)
            {
                //Стъпка 5 - въвеждаме Input данните по условие и премахваме "_";
                string[] data = Console.ReadLine().Split("_");

                //Стъпка 6 - създаваме променливи type, name, newTime и взимаме стойностите им
                //от масива data който вчера сме разбили на парченца [0], [1], [2]
                string type = data[0];
                string name = data[1];
                string newTime = data[2];

                //Стъпка 7 - създаваме !!променлива song която е от Class-a Song който вече създадохме
                //тази променлива приема свойствата на класа Song и същевременно я оставяме празна
                //с дефоутни стойности Nill
                Song song = new Song();

                //Стъпка 8 - с тази стъпка вкарваме данните която променливата song от class Songs трябва да приеме.
                //след song.(извикваме свойството към което искаме да запишем данни)
                //song.Typlist = type -> Това означава че свойството на song.Typlist приема стойността на Type и т.н;
                song.TypeList = type;
                song.Name = name;
                song.Time = newTime;
                
                //Стъпка 9 - добавяме (свойството - name) в листа listOfSongs който е от тип class Songs
                listOfSongs.Add(song);

                //Стъпка 10 - завъртаме цикъла още Х пъти
            }

            //Стъпка 11 - Въвеждаме команда какво искаме да отпечатаме
            string typeList = Console.ReadLine();

            //ако командата е all отпечатваме всички песни
            if (typeList == "all")
            {   
                //използваме foreach
                foreach (var song in listOfSongs)
                {   //от listOfSongs принтираме свойството на обекта song.Name 
                    Console.WriteLine(song.Name);
                }
            }
            //Ако искаме да принтираме определен TypeList
            else
            {   //обхождаме целия listOfSongs
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
