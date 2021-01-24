using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> listOfDemons = new List<Demon>();

            string numberPattern = @"[-+]?[0-9]+\.?[0-9]*";
            Regex numbersRegex = new Regex(numberPattern);

            char[] separator = { ' ', ',' };
            var inputDemons = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);


            foreach (var demon in inputDemons)
            {
                string filter = "0123456789+-/.*";
                int health = demon.Where(c => !filter.Contains(c)).Sum(c => c);
                double damage = CalculateDamage(numbersRegex, demon);

                listOfDemons.Add(new Demon { Name = demon, Health = health, Damage = damage });
            }

            foreach (var demon in listOfDemons.OrderBy(d=> d.Name))
            {
                Console.WriteLine(demon);
            }
        }

        private static double CalculateDamage(Regex numbersRegex, string demon)
        {
            MatchCollection mathchedNumbers = numbersRegex.Matches(demon);

            double currDamage = 0;

            foreach (Match currNum in mathchedNumbers)
            {
                currDamage += double.Parse(currNum.Value);
            }

            foreach (Char symbol in demon)
            {
                if (symbol == '*')
                {
                    currDamage *= 2.0;
                }
                else if (symbol == '/')
                {
                    currDamage /= 2.0;
                }
            }

            return currDamage;
        }
    }

}


