using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(string firstName, string lastName, int id, decimal salary, string corp) 
            : base(firstName, lastName, id, salary, corp)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repair
        {
            get 
            {
                return (IReadOnlyCollection<IRepair>)this.repairs;
            }
        }

        public void AddRepair(IRepair newRepair)
        {
            this.repairs.Add(newRepair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb  
                .AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
