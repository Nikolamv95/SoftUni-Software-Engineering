using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary) 
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }
    }
}
