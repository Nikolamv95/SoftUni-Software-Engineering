using MilitaryElite.Contracts;
using MilitaryElite.Enumerators;
using MilitaryElite.Exceptions;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }

        public string CodeName { get; private set; }
        public MissionState State { get; private set; }

        private MissionState TryParseState(string state)
        {
            //This is the way how we Try to parse string value in to a Enum object (Corps corp);
            bool parsed = Enum.TryParse<MissionState>(state, out MissionState newState);

            if (!parsed)
            {
               throw new InvalidMissionStateException();//Why after handeling the exception the program stopped
            }

            return newState;

        }
        public void CompleteMission()
        {
            if (this.State == MissionState.Finished)
            {
                throw new InvalidMissionCompleatedException();
            }

            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
