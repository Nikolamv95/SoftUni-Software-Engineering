using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(string firstName, string lastName, int id, decimal salary, string corp)
            : base(firstName, lastName, id, salary, corp)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Mission
        {
            get
            {
                return (IReadOnlyCollection<IMission>)this.missions;
            }
        }

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
