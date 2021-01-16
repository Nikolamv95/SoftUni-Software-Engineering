using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBookV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> listSideAndUsers = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string command = string.Empty;

                if (input.Contains(" | "))
                {
                    command = "|";
                }
                else if (input.Contains(" -> "))
                {
                    command = "->";
                }


                switch (command)
                {
                    case "|":
                        var forceUser = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        string sideForce = forceUser[0];
                        string userForce = forceUser[1];

                        if (listSideAndUsers.ContainsKey(sideForce) == false)
                        {
                            List<string> usersToAdd = new List<string> { userForce };
                            listSideAndUsers.Add(sideForce, usersToAdd);
                        }
                        else
                        {
                            if (listSideAndUsers[sideForce].Contains(userForce) == false)
                            {
                                listSideAndUsers[sideForce].Add(userForce);
                            }
                        }
                        break;
                    case "->":
                        var forceSide = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                        string userToJoin = forceSide[0];
                        string sideToJoin = forceSide[1];

                        if (UserExist(listSideAndUsers, userToJoin, sideToJoin))
                        {
                            foreach (var item in listSideAndUsers)
                            {
                                if (item.Value.Contains(userToJoin))
                                {
                                    item.Value.Remove(userToJoin);
                                }
                            }
                            listSideAndUsers[sideToJoin].Add(userToJoin);
                            Console.WriteLine($"{userToJoin} joins the {sideToJoin} side!");
                        }
                        else
                        {
                            listSideAndUsers[sideToJoin].Add(userToJoin);
                            Console.WriteLine($"{userToJoin} joins the {sideToJoin} side!");
                        }
                        break;
                }
            }

            foreach (var kvp in listSideAndUsers.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }

        private static bool UserExist(Dictionary<string, List<string>> listSideAndUsers, string userToJoin, string sideToJoin)
        {
            bool isExist = false;

            foreach (var item in listSideAndUsers)
            {
                if (item.Value.Contains(userToJoin))
                {
                    isExist = true;
                }
            }

            return isExist;
        }
    }
}
