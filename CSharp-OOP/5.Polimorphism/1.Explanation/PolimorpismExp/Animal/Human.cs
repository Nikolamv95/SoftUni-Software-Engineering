using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class Human
    {
        public Animal Pet { get; set; }

        public Human(Animal pet)
        {
            this.Pet = pet;
        }

        public void Feed()
        {
            Pet.Eat(" Wiskas");
        }

        public void PutToSleep()
        {
            Pet.Sleep();
        }
    }
}
