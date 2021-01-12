using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkProjects
{
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
