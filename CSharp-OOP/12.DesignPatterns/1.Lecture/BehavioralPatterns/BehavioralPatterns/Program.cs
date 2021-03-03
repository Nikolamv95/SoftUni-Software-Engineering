using ChainOfResponsibility;
using System;

namespace BehavioralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver teamLead = new TeamLead();
            Approver cto = new CTO();
            teamLead.SetNext(cto);
            Console.WriteLine(teamLead.HandleRequest(3));
            Console.WriteLine(teamLead.HandleRequest(400));
            Console.WriteLine(teamLead.HandleRequest(1000));
        }
    }
}
