using System;

namespace VirtualsAndOverride
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Sleep();

            var child = new Child();
            child.Sleep();

            var robot = new Robot();
            robot.Sleep();
        }

    }
}
