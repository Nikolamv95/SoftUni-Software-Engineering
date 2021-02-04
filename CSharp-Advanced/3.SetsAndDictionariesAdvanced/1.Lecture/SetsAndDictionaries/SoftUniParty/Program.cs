using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setVipGuest = new HashSet<string>();
            HashSet<string> setRegualrGuest = new HashSet<string>();

            string guestsToCome = string.Empty;

            while ((guestsToCome = Console.ReadLine()) != "PARTY")
            {
                if (guestsToCome.Length > 8)
                {
                    continue;
                }

                //VIP Guest
                if (char.IsDigit(guestsToCome[0]))
                {
                    setVipGuest.Add(guestsToCome);
                }
                else
                {
                    setRegualrGuest.Add(guestsToCome);
                }
            }

            string guestsAlreadyCame = string.Empty;

            while ((guestsAlreadyCame = Console.ReadLine()) != "END")
            {
                //VIP Guest
                if (char.IsDigit(guestsAlreadyCame[0]))
                {
                    setVipGuest.Remove(guestsAlreadyCame);
                }
                else
                {
                    setRegualrGuest.Remove(guestsAlreadyCame);
                }
            }

            int peopleDidntCome = setVipGuest.Count + setRegualrGuest.Count;
            Console.WriteLine(peopleDidntCome);

            if (setVipGuest.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, setVipGuest));
            }
            if (setRegualrGuest.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, setRegualrGuest));
            }
        }
    }
}
