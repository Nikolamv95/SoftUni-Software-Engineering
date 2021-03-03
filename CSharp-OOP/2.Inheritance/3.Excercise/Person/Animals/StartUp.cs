using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string animalInput = string.Empty;
            List<Animals> animals = new List<Animals>();

            while ((animalInput = Console.ReadLine()) != "Beast!")
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                try
                {
                    switch (animalInput)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender)); break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender)); break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender)); break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age)); break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age)); break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in animals)
            {
                Console.WriteLine($"{item.GetType().Name}");
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
