using System;
using System.Collections.Generic;
using System.Text;

namespace ojectsAndClasses
{
    class Dice
    {
        public Dice(int sides)
        {
            Sides = sides;
        }

        public int Sides  { get; set; }
        public string Type  { get; set; }

        public int Roll()
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, Sides+1);
            return roll;
        }

    }
}
