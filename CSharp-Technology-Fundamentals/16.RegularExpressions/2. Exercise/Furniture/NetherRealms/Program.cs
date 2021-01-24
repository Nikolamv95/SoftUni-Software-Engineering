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
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> listOfDemons = new List<Demon>();

            string numberPattern = @"[-+]?[0-9]+\.?[0-9]*";
            string textPatern = @"([a-zA-Z])+";
            string combinationSequence = @"[/*]+";

            char[] separator = { ' ', ',' };
            var inputDemons = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputDemons.Length; i++)
            {
                MatchCollection matchesForNumbers = Regex.Matches(inputDemons[i], numberPattern);
                MatchCollection matchesForText = Regex.Matches(inputDemons[i], textPatern);
                MatchCollection matchesForCombination = Regex.Matches(inputDemons[i], combinationSequence);

                // Step 1 - Taka damage value
                double sumForDamage = 0;
                foreach (Match item in matchesForNumbers)
                {
                    double digit = double.Parse(item.Value);
                    sumForDamage += digit;
                }

                foreach (Match item in matchesForCombination)
                {
                    string sequence = item.Value;
                    char[] charSequence = sequence.ToCharArray();

                    for (int k = 0; k < charSequence.Length; k++)
                    {
                        char currSeq = charSequence[k];

                        if (currSeq == '*' && sumForDamage > 0)
                        {
                            sumForDamage *= 2;
                        }
                        else if (currSeq == '/' && sumForDamage > 0)
                        {
                            sumForDamage /= 2;
                        }
                    }
                }
                // Sum Damage Taken //

                // Step 2 - Taka Health value
                int sumForHealth = 0;

                foreach (Match letter in matchesForText)
                {
                    int currDigit = 0;

                    string currLetter = letter.Value;
                    char[] charLetters = currLetter.ToCharArray();

                    for (int z = 0; z < charLetters.Length; z++)
                    {
                        currDigit = currLetter[z];
                        sumForHealth += currDigit;
                    }
                }
                // Sum Health Taken //

                string name = inputDemons[i];

                Demon currDemon = new Demon();

                currDemon.Name = name;
                currDemon.Health = sumForHealth;
                currDemon.Damage = sumForDamage;

                listOfDemons.Add(currDemon);
            }

            foreach (var item in listOfDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Health} health, {item.Damage:f2} damage");
            }
        }
    }

}


