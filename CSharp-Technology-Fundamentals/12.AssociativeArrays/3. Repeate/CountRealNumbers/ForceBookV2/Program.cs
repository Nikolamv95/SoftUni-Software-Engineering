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
                var sideOrUser = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = sideOrUser[1];
                

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

                        if (UserExist (listSideAndUsers, userToJoin, sideToJoin))
                        {
                            
                        }
                        else
                        {
                            listSideAndUsers[sideToJoin].Add(userToJoin);
                            Console.WriteLine($"{userToJoin} joins the {sideToJoin} side!");
                        }
                        break;
                }
            }
        }

        private static bool UserExist(Dictionary<string, List<string>> listSideAndUsers, string userToJoin, string sideToJoin)
        {
            bool isExist = false;

            foreach (var item in listSideAndUsers)
            {
                foreach (var user in item.Value)
                {
                    if (user == userToJoin)
                    {
                        isExist = true;
                        break;
                    }
                }
            }

            return isExist;
        }
    }
}
