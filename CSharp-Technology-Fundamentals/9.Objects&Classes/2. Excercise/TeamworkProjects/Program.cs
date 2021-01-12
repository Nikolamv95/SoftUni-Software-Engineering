using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 -> Създаване на Class Team
            //Стъпка 2 - Дефиниране на броя отбори които ще създаваме
            int teamCount = int.Parse(Console.ReadLine());
            //Стъпка 3 - Създаваме лист в който ще държим отборите
            //Обяснение!! този лист ще съдържа всички отбори като пропъртитата на тези отбори са:
            //TeamName; CreatorName; и !!! друг лист List<string> Members в който ще запаметяваме членовете на отбора
            List<Team> listOfTeams = new List<Team>();

            StringBuilder sb = new StringBuilder();

            //Стъпка 4 - Създаваме отборите и правим проверките по условия
            for (int i = 0; i < teamCount; i++)
            {
                //Стъпка 5 - разделяме input който получаваме в масив
                string[] input = Console.ReadLine()
                                .Split("-");

                string creatorName = input[0];
                string teamName = input[1];

                //Стъпка 6 - Викаме класа(инстанцията) и вкарваме данните в него teamName и creatorName
                Team team = new Team(teamName,creatorName);

                //Стъпка 7 - създаваме булева променливав която ще ни върне True или False дали отбор с това име вече
                //съществува. За тази цел използваме следните функции. Викаме основния лист и с функция селек избираме
                //и преминаваме през всички имена на отбори които вече са записани -> "Select(x => x.TeamName)"
                //след това докато преминаваме през всички отбори използваме втора функция "Contains(teamName)"
                //която проверява дали името което е вкарано от "teamName = input[1]" вече съществува.
                bool isTeamExist = listOfTeams
                                                .Select(x => x.TeamName)
                                                .Contains(teamName);

                //Стъпка 8 - е сходна на стъпка 7. Проверяваме дали човекът който се опитва да създаде отбор
                //вече е създал друг.
                bool isCreatorExist = listOfTeams
                                                    .Select(x => x.CreatorName)
                                                    .Contains(creatorName);

                //Стъпка 9 - проверяваме дали този отбор НЕ съществува, ако условието е вярно влизаме
                // и добавяме отбора към списъка listOfTeams
                if (!isTeamExist)
                {
                    if (!isCreatorExist)
                    {
                        listOfTeams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {   //Ако съществува отпечатваме, че вече съществува
                    Console.WriteLine($"Team {teamName} was already created!");
                } 
            }

            //Стъпка 10 - Започваме да вкарваме хора в отборите
            string teamMembers = Console.ReadLine();

            //Стъпка 11 - вкарваме хора докато не получим команда "end of assignment"
            while (teamMembers != "end of assignment")
            {
                string[] input = teamMembers.Split(new char[] {'-','>'}).ToArray();//Друг начин за премахване на излишни символи

                string newUser = input[0];
                string teamName = input[2];

                //Стъпка 12 - същата като стъпка 7 и 9. Проверяваме дали отборът съществува
                bool isTeamExist = listOfTeams
                                            .Select(x => x.TeamName)
                                            .Contains(teamName);
                //Стъпка 13 - същата като стъпка 12. Проверяваме дали създателя иска да се премести -> НЕ МОЖЕ
                bool isCreatorExist = listOfTeams
                                            .Select(x => x.CreatorName)
                                            .Contains(newUser);
                //Стъпка 14 - същата като стъпка 13. ВАЖНО!! Тук влизаме в друг лист List<string>Members и трябва да обходим целия лист
                //за да стане това нещо използваме функцията .Any която проверява дали дадена колекция съдържа някакъв елемент

                bool isMemberxist = listOfTeams
                                            .Select(x => x.Members)
                                            .Any(x => x.Contains(newUser)); //В Any проверяваме дали в Members листа ни newUser вече съществува
                if (!isTeamExist)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isMemberxist || isCreatorExist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {   //Взимаме индекса на отборът в който ще добавяме играч.
                    int indexOfTeam = listOfTeams.FindIndex(x => x.TeamName == teamName);
                    //След това влизаме в основния лист и в конкретния отбор(става чрез индекса на отбора)
                    //като влезем в този отобр пишем функцията .Add() и добавяме новия user == newUser
                    listOfTeams[indexOfTeam].Members.Add(newUser);
                }

                teamMembers = Console.ReadLine();
            }

            //Стъпка 15 - Дисквалифицираме отборите които нямат members а само създатели. 
            //1 Сортираме ги по име, 
            //2 с Where взимаме отборите които в списъка Members имат 0 членове,
            Team[] teamsToDisband = listOfTeams.OrderBy(x => x.TeamName)
                                               .Where(x => x.Members.Count == 0)
                                               .ToArray();
            //Стъпка 16 - Сортираме легитимните тимове по броя не мембърите им (OrderByDescending)
            //и по името (ThenBy) и взимаме отборите които имат team members
            Team[] eligibleTeams = listOfTeams.OrderByDescending(x => x.Members.Count)
                                              .ThenBy(x => x.TeamName)
                                              .Where(x => x.Members.Count > 0)
                                              .ToArray();
            //Стъпка 17 - Отпечатваме със StringBuilder и foreach отборите които са легитимни да участват
            

            //Първо изписваме отборът и името на създателя
            foreach (Team team in eligibleTeams)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");
                //след това изписваме Members които се намират в List Members като ги подредим по азбучен ред
                //team.Members.OrderBy(x=>x) -> променливата team от горния форий чете пропъртитата и затова чрен нея достъпваме пропъртито (лист) Members
                foreach (var members in team.Members.OrderBy(x=>x))
                {
                    sb.AppendLine($"-- {members}…");
                }
                
            }
            //Стъпка 18 отпечатваме отборите които не могат да участват
            sb.AppendLine($"Teams to disband:");
            foreach (Team teams in teamsToDisband)
            {
                sb.AppendLine($"{teams.TeamName}");
            } 
            //Стъпка 19 - печатаме на конзолата
            Console.WriteLine(sb);
        }

        class Team
        {
            //Стъпка 3 - дефинираме конструктор

            public Team(string teamName, string creatorName)
            {
                TeamName = teamName;
                CreatorName = creatorName;
                //ИЗКЛЮЧИТЕЛНО ВАЖНО -> Трябва да дефинираш листа вътре в конструктура, за да съществува
                //въпреки че горе "public Team(string teamName, string creatorName)" в скобите не го дефинираш
                //по този начин данните които вписваш ще се запазят в листа Members
                Members = new List<string>();
            }

            //Стъпка 2 - дефинираме пропъртитата на класа Team
            public string TeamName { get; set; }
            public string CreatorName { get; set; }
            public List<string> Members { get; set; }
        }

    }
}
