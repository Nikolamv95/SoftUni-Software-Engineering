using System;
using System.Collections.Generic;
using System.Linq;

using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        protected Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer) 
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                decimal salary = 0;
                string corp = string.Empty;
                //We create an instance of ISoldier which we gonna use later. ISoldier is the base class, so we can call all types of soldier trough it.
                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        AddPrivate(cmdArgs, id, firstName, lastName, out salary, out soldier);
                        break;

                    case "LieutenantGeneral":
                        AddGeneral(cmdArgs, id, firstName, lastName, out salary, out soldier);
                        break;

                    case "Engineer":
                        
                        salary = decimal.Parse(cmdArgs[4]);
                        corp = cmdArgs[5];
                        
                        try
                        {
                            IEngineer engenier = CreateEngineer(cmdArgs, id, firstName, lastName, salary, corp);
                            soldier = engenier;//soldier takes the arguments of engenier
                        }
                        catch (InvalidCorpsException se)
                        {
                            continue;
                        }
                        break;

                    case "Commando":
                        
                        salary = decimal.Parse(cmdArgs[4]);
                        corp = cmdArgs[5];
                        
                        try
                        {
                            ICommando commando = GetCommando(cmdArgs, id, firstName, lastName, salary, corp);
                            soldier = commando;
                        }
                        catch (InvalidCorpsException se)
                        {
                            continue;
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(cmdArgs[4]);
                        soldier = new Spy(firstName, lastName, id, codeNumber);
                        break;
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ICommando GetCommando(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corp)
        {
            ICommando commando = new Commando(firstName, lastName, id, salary, corp);

            string[] missionArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string missionName = missionArgs[i];
                    string statusMission = missionArgs[i + 1];

                    IMission mission = new Mission(missionName, statusMission);
                    commando.AddMission(mission);
                }
                catch 
                { 
                    continue; 
                }
            }

            return commando;
        }
        private static IEngineer CreateEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corp)
        {
            IEngineer engenier = new Engineer(firstName, lastName, id, salary, corp);//Check tomorrow
            string[] repairArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engenier.AddRepair(repair);
            }

            return engenier;
        }
        private void AddGeneral(string[] cmdArgs, int id, string firstName, string lastName, out decimal salary, out ISoldier soldier)
        {
            salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(firstName, lastName, id, salary);//Try with ILie...

            foreach (var item in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(item));
                general.AddPrivate(privateToAdd);
            }

            soldier = general;//Check later
        }
        private void AddPrivate(string[] cmdArgs, int id, string firstName, string lastName, out decimal salary, out ISoldier soldier)
        {
            salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(firstName, lastName, id, salary);
        }
    }
}
