using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowingMembers_Classes
{
    class Event
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }

        public void Start()
        {
            Console.WriteLine("Event is starting");
        }


    }
}
