using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            //Създаваме колекция дикшънъри с вложен дикшънъри от стринг и хашсет
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            
            while ((input = Console.ReadLine()) != "Statistics")
            {
                //Взиамаме inputa
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string firstVlogerName = data[0];
                string operation = data[1];
                //Проверяваме дали влогъра се присъединява към The V-Logger или ще follow-ва друг влогър
                switch (operation)
                {
                    case "joined":
                        //Ако не съществува го добавяме в дикшънърито и задаваме 2 стойности с вложен хашсет вътре.
                        if (app.ContainsKey(firstVlogerName) == false)
                        {
                            //Добавяме влогъра
                            app.Add(firstVlogerName, new Dictionary<string, SortedSet<string>>());
                            //Дефинираме че първия ключ на вложения речник се казва followers, a втория following,
                            //като всеки от тях има сортед хашсет, като той е празен за сега/
                            app[firstVlogerName].Add("followers", new SortedSet<string>());
                            app[firstVlogerName].Add("following", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        string secondVloger = data[2];

                        //Проверяваме дали условията са верни и ако са прскачаме тази стъпка
                        if (firstVlogerName == secondVloger || !app.ContainsKey(firstVlogerName) || !app.ContainsKey(secondVloger) )
                        {
                            continue;
                        }
                        //Тук влогър 1 започва да следва влогър 2, затова към влогър 1 в ключ following добавяме втория влогър.
                        app[firstVlogerName]["following"].Add(secondVloger);
                        //След като знаем че влогър 1 следва влогър 2, то за влогър 2 -> влогър 1 му е follower.
                        //Затова в ключ followers на влогър 2 добавяме волгър 1.
                        app[secondVloger]["followers"].Add(firstVlogerName);

                        //Тъй като имаме хашсет няма да се допусне дублиране на влогъри които следват един и същи човек 2 пъти.
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");
            int counter = 1;

            //Филтрираме списъка по брой followers и след това по брой following
            //Тъй като value-то на основния речник app е вложен речник с key -> followers/following и value SortedHasSet
            //ние можем да достъпким Key на втория речник по този начин -> kvp.Value["followers"]
            var filtApp = app.OrderByDescending(kvp => kvp.Value["followers"].Count)
                         .ThenBy(kvp => kvp.Value["following"].Count);

            //Разбиваме структурата на дикшинърито като са ключ и стойност даваме нови променливи
            //App key -> vlogger, value -> вложения речник с променлива vloggerProfile. По този начин 
            //ги достъпваме по-лесно надолу при печата.
            foreach ((string vlogger, Dictionary<string, SortedSet<string>> vloggerProfile) in filtApp)
            {
                Console.WriteLine($"{counter++}. {vlogger} : {vloggerProfile["followers"].Count} " +
                                  $"followers, {vloggerProfile["following"].Count} following");

                if (counter == 2)
                {
                    foreach (var values in vloggerProfile["followers"])
                    {
                        Console.WriteLine($"*  {values}");
                    }
                }
            }
            
        }
    }
}
