using System;

namespace WorkWithSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            //string password = Console.ReadLine();

            //if (password == "s3cr3t!P@ssw0rd")
            //{
            //    Console.WriteLine("Welcome");
            //}
            //else if (password != "s3cr3t!P@ssw0rd")
            //{
            //    Console.WriteLine("Wrong password!");
            //}

            string password = Console.ReadLine();

            switch (password)
            {
                case ("s3cr3t!P@ssw0rd"):
                    
                    Console.WriteLine("Welcome");
                    
                    break;

                case ("s3cr3t!P@ssw0rd11"):

                    Console.WriteLine("Wrong Password");

                    break;

            }

        }
    }
    
}
