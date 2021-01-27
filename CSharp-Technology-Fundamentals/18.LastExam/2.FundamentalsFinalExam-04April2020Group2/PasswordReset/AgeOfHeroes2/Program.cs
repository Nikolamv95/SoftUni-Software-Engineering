using System;
using System.Collections.Generic;
using System.Linq;

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

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                                   .Split(" - ",StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                string action = data[0];
                string heroName = data[1];

                switch (action)
                {
                    case "CastSpell":
                        int castSpell = int.Parse(data[2]);
                        string castName = data[3];
                        CastSpell(listOfHeroes, heroName, castSpell, castName);
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(data[2]);
                        string attacker = data[3];
                        TakeDamage(listOfHeroes, heroName, damage, attacker);
                        break;
                    case "Recharge":
                        int amountMp = int.Parse(data[2]);
                        RechargeAction(listOfHeroes, heroName, amountMp);
                        break;
                    case "Heal":
                        int amountHp = int.Parse(data[2]);
                        HealAction(listOfHeroes, heroName, amountHp);
                        break;
                }
            }

            var filtList = listOfHeroes.OrderByDescending(h => h.HitPoints).ThenBy(n => n.Name);

            foreach (var item in filtList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"HP: {item.HitPoints}");
                Console.WriteLine($"MP: {item.ManaPoints}");
            }
        }

        private static void CastSpell(List<Heroe> listOfHeroes, string heroName, int castSpell, string castName)
        {
            //CastSpell = MP
            var curr = listOfHeroes.Single(x => x.Name == heroName);
            //Check Later
            if (curr.ManaPoints >= castSpell)
            {
                curr.ManaPoints -= castSpell;
                Console.WriteLine($"{heroName} has successfully cast {castName} and now has {curr.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {castName}!");
            }
        }

        private static void TakeDamage(List<Heroe> listOfHeroes, string heroName, int damage, string attacker)
        {
            //Damage = HP
            var curr = listOfHeroes.Single(x => x.Name == heroName);

            if (curr.HitPoints > damage)
            {
                curr.HitPoints -= damage;
                int currHp = curr.HitPoints;
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currHp} HP left!");
            }
            else
            {
                listOfHeroes.RemoveAll(hero => hero.Name == heroName);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        private static void RechargeAction(List<Heroe> listOfHeroes, string heroName, int amountMp)
        {
            var curr = listOfHeroes.Single(x => x.Name == heroName);

            if (curr.ManaPoints + amountMp <= 200)
            {
                curr.ManaPoints += amountMp;
                Console.WriteLine($"{heroName} recharged for {amountMp} MP!");
            }
            else
            {
                int mpToAdd = 200 - curr.ManaPoints;
                curr.ManaPoints += mpToAdd;
                Console.WriteLine($"{heroName} recharged for {mpToAdd} MP!");
            }

        }

        private static void HealAction(List<Heroe> listOfHeroes, string heroName, int amountHp)
        {
            var curr = listOfHeroes.Single(x => x.Name == heroName);

            if (curr.HitPoints + amountHp <= 100)
            {
                curr.HitPoints += amountHp;
                Console.WriteLine($"{heroName} healed for {amountHp} HP!");
            }
            else
            {
                int hpToAdd = 100 - curr.HitPoints;
                curr.HitPoints += hpToAdd;
                Console.WriteLine($"{heroName} healed for {hpToAdd} HP!");
            }
        }
    }
}