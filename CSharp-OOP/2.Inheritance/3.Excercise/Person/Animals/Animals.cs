using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animals
    {
        private string name;
        private int age;
        private string gender;

        public Animals(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        private string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        private int Age
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        private string Gender
        {
            set
            {
                Gender gender;
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out gender))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = gender;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBilder sb = new StringBilder();

        }
    }
}
 