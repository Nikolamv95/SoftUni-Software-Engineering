using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Pet : IName, IBirthday
    {
        public Pet(string name, string birthDay)
        {
            this.Name = name;
            this.Birthday = birthDay;
        }

        public string Name { get; private set; }
        public string Birthday { get; private set; }
    }
}
