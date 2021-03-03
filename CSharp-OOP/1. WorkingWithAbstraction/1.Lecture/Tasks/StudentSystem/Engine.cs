using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    class Engine
    {
        private StudentData studentData;

        public Engine(StudentData student)
        {
            this.studentData = student;
        }

        public void Process()
        {
            var end = false;

            while (!end)
            {
                var line = Console.ReadLine();
                var command = Command.Parse(line);

                var name = command.Name;
                var arguments = command.Arguments;

                switch (name)
                {
                    case "Create":
                        this.studentData.Add(arguments[0], int.Parse(arguments[1]), double.Parse(arguments[2]));
                        break;
                    case "Show":
                        var details = this.studentData.GetStudent(arguments[0]);
                        Console.WriteLine(details);
                        break;
                    case "Exit":
                        end = true;
                        break;
                }
            }
        }
    }
}
