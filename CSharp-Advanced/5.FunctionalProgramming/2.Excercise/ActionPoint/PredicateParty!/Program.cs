using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfPeople = Console.ReadLine().Split().ToList();
           
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] data = command.Split();
                string currCommand = data[0];
                string operation = data[1];
                string sequence = data[2];

                Predicate <string> predicate = GetPredicate(operation, sequence);

                switch (currCommand)
                {
                    case "Double":
                       List<string> matches = listOfPeople.FindAll(predicate);
                        if (matches.Count > 0)
                        {
                            var index = listOfPeople.FindIndex(predicate);
                            listOfPeople.InsertRange(index, matches);
                        }
                        break;
                    case "Remove":
                        listOfPeople.RemoveAll(predicate);
                        break;
                }

               
            }

            if (listOfPeople.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", listOfPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        static Predicate<string> GetPredicate(string operation, string sequence)
        {
            switch (operation)
            {
                case "StartsWith": return name => name.StartsWith(sequence);
                case "EndsWith": return name => name.EndsWith(sequence);
                case "Length": return name => name.Length == int.Parse(sequence);
                default: return null;
            }
        }
    }
}
