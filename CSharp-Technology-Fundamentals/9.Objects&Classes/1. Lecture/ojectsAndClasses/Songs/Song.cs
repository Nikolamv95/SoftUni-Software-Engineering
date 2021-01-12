using System;
using System.Collections.Generic;
using System.Text;

namespace Songs
{
    class Song
    {   //Стъпка 2 -> Създаваме Class Song в който дефинираме
        //какви свойства има този клас TypeList, Name, Time
        //Тези стойности са отворени и ще се подадат от Class Program ->
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
