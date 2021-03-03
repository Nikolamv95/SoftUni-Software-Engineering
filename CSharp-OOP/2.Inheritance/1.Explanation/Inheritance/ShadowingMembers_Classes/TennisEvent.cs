using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowingMembers_Classes
{
    class TennisEvent : Event
    {

        //Въпреки че в Base класа Duration е int в наследника ние можем да променим вида на данни за конкретното пропърти
        //public int Duration { get; set; }
        public DateTime Duration { get; set; }

        //Викайки метода Start() на TennisEvent(), ние ще отпечатаме Zagrqvka и Start() метода на Event()
        public new void Start()
        {
            Console.WriteLine("Zagrqvka");
            base.Start();
        }

        public void PrintEvent()
        {
            this.Duration = DateTime.Now;
            base.Duration = 5;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Peshaka";
        }
    }
}
