using System;

namespace VirtualsAndOverride
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Въпреки че и двата класа наследяват Person и методите му можем да направим различна функционалност за всеки клас
            //Това става като пред метода в основния клас сложим Virtual -> public virtual void Sleep()
            //а в останалите класове извикаме този метод с override -> public override void Sleep() и вътре разпишен каква функционалност
            //искаме конкретния клас да има с този метод

            var person = new Person();
            person.Sleep();

            var child = new Child();
            child.Sleep();

            var robot = new Robot();
            robot.Sleep();
        }

    }
}
