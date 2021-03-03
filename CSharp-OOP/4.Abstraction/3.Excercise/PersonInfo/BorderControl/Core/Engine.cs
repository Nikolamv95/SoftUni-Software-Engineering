using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private List<IBuyer> buyersList;
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.buyersList = new List<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer) 
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int rows = int.Parse(reader.ReadLine());
            AddPopulation(rows);
            AddingFood();
            PrintFood();
        }

        private void AddingFood()
        {
            string inputName = string.Empty;
            while ((inputName = reader.ReadLine()) != "End")
            {
                foreach (IBuyer item in this.buyersList)
                {
                    var castObjcet = (IName)item;
                    if (castObjcet.Name == inputName)
                    {
                        item.BuyFood();
                    }
                }
            }
        }
        private void AddPopulation(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] args = reader.ReadLine().Split().ToArray();
                string name = args[0];
                int age = int.Parse(args[1]);

                if (args.Length == 4)
                {
                    AddCitizen(args, name, age);
                }
                else if (args.Length == 3)
                {
                    AddRebel(args, name, age);
                }
            }
        }
        private void AddRebel(string[] args, string name, int age)
        {
            string group = args[2];
            IBuyer rebel = new Rebel(name, age, group);
            this.buyersList.Add(rebel);
        }
        private void AddCitizen(string[] args, string name, int age)
        {
            string id = args[2];
            string birthDay = args[3];
            IBuyer citizen = new Citizen(name, age, id, birthDay);
            this.buyersList.Add(citizen);
        }
        private void PrintFood()
        {
            int sum = this.buyersList.Sum(n => n.Food);
            writer.WriteLine(sum.ToString());

            //If I change the interface to ITem I have acess to the name of the objects in the collection birthdayPop
            ////foreach (IName item in this.birthdayPop)
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}


