using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfCode
{
    class Heroe
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());
            List<Heroe> listOfHeroes = new List<Heroe>();

            for (int i = 0; i < numOfHeroes; i++)
            {
                string[] data = Console.ReadLine()
                                        .Split(' ')
                                        .ToArray();

                string name = data[0];
                int hitPoints = int.Parse(data[1]);
                int manaPoints = int.Parse(data[2]);

                Heroe currHero = new Heroe();

                if (hitPoints > 100)
                {
                    hitPoints = 100;
                }
                if (manaPoints > 200)
                {
                    manaPoints = 200;
                }

                currHero.Name = name;
                currHero.HitPoints = hitPoints;
                currHero.ManaPoints = manaPoints;
                listOfHeroes.Add(currHero);
            }
        }
    }
}




//if (listOfHeroes.Any(h=>h.Name == name))
//{
//    var curr = listOfHeroes.Single(x => x.Name == name);

//    //maximum of 100 HP and 200 MP

//    if (curr.HitPoints + hitPoints <= 100)
//    {
//        curr.HitPoints += hitPoints;
//    }
//    else
//    {

//    }

//    if (curr.ManaPoints + manaPoints <= 200)
//    {
//        curr.ManaPoints += manaPoints
//    }
//}
//else
//{
//    currHero.Name = name;
//    currHero.HitPoints = hitPoints;
//    currHero.ManaPoints = manaPoints;
//    listOfHeroes.Add(currHero);
//}