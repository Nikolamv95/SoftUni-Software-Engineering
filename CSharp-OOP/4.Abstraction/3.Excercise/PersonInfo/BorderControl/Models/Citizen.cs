using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : IName, IBirthday, IIds, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDay)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthDay;
            this.Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
