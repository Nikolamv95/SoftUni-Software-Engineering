using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);

            //We can change the type of a certain clas by using Conver.ChangeType method
            //If we want to converth IIdentifiable interfaice to class Citizen we just have to use:
            Type type = identifiable.GetType();
            Citizen citizen = (Citizen)Convert.ChangeType(identifiable, type);
            //After we convert the type of the object identifiable we can use the functionallity of the class Citizen. 
        }
    }
}
