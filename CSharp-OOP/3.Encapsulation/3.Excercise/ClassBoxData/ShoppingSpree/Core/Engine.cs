using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        //Read data from the console
        //Process data -> Manipulate, Save to db
        //Print data on the console

        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        //Place business logic in Run()
        public void Run()
        {
            try
            {
                ParsePeopleInput();
                ParseProductInput();

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = this.people.FirstOrDefault(x => x.Name == personName);//FirstOrDefault връща Null, по-добре е от Single
                    Product product = this.products.FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.Purchase(product);
                        Console.WriteLine(result);
                    }
                }

                foreach (var person in this.people)
                {
                    Console.WriteLine(person);
                }
            
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }



        }

        private void ParsePeopleInput()
        {
            string[] peopleArg = Console.ReadLine()
                                                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                                    .ToArray();

            foreach (var personStr in peopleArg)
            {
                string[] personArgs = personStr
                                        .Split('=', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);
                this.people.Add(person);
            }
        }

        private void ParseProductInput()
        {

            string[] productArg = Console.ReadLine()
                                      .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

            foreach (var productStr in productArg)
            {
                string[] productArgs = productStr
                                        .Split('=', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string productName = productArgs[0];
                decimal productPrice = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productPrice);
                this.products.Add(product);
            }
        }
    }
}
