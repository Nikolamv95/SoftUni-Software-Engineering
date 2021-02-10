using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> namesList = Console.ReadLine().Split().ToList();
            List<string> listOfCommands = new List<string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] data = command.Split(";");
                string operation = data[0];
                string filterType = data[1];
                string argument = data[2];


                if (operation == "Add filter")
                {
                    listOfCommands.Add($"{filterType};{argument}");
                }
                else if (operation == "Remove filter")
                {
                    listOfCommands.Remove($"{filterType};{argument}");
                }
            }

            foreach (var item in listOfCommands)
            {
                string[] data = item.Split(";");
                string filterType = data[0];
                string argument = data[1];

                switch (filterType)
                {
                    case "Starts with":
                        namesList = namesList.Where(x => x[0].ToString() != argument).ToList();
                        break;
                    case "Ends with":
                        namesList = namesList.Where(x => x[x.Length-1].ToString() != argument).ToList();
                        break;
                    case "Length":
                        namesList = namesList.Where(x=>x.Length != int.Parse(argument)).ToList();
                        break;
                    case "Contains":
                        namesList = namesList.Where(p=>!p.Contains(argument)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', namesList));
        }
    }
}
