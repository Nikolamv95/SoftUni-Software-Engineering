using MilitaryElite.Contracts;
using MilitaryElite.Core;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;

        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
        {
            get
            {
                return (IReadOnlyCollection<ISoldier>)this.privates;
            }
        }

        public void AddPrivate(ISoldier newPrivate)
        {
            this.privates.Add(newPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in this.privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
