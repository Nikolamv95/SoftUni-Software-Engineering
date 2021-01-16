using System;
using System.Collections.Generic;

namespace wordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {   //Стъпка 1 - взимаме броя комбинации които ще се вкарат
            int numberOfWords = int.Parse(Console.ReadLine());
            //Стъпка 2 - създаваме Dictionary "words" със key-string и value-List защото в листа ще се
            //запишат няколко стойности, а не само 1.
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            //Стъпка 4 - обхождаме Dictionary n брой пъти и вкарваме данните в него
            for (int i = 0; i < numberOfWords; i++)
            {
                //Взимаме инпута който ни е даден
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                //Стъпка 5 - ако думата (word) вече съществува, трябва да добавим с списъка към нея
                //синонима който ни се подава от "synonym"
                if (words.ContainsKey(word))
                {
                    //извикваме dicitonary words и стойността му [word] и добавяме синонима към него.(VALUE)
                    words[word].Add(synonym);
                }
                else
                {
                    //Ако не съществува думата, добавяме я, дефинираме да се създаде под списък към нея 
                    //и добавяме синонима в самия списък. В случая списъка е Value и в него добавяме под-стойности
                    words.Add(word, new List<string>() {synonym});
                    //words[word].Add(synonym);

                    //Можем да вкараме стойността в списъка по 2 начина. Директно на горния ред след списъка
                    //или да напишем нов ред като в if проверката.
                }
            }

            //Стъпка 6 - печатаме otuput
            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
