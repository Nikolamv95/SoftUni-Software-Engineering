using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class TeamLead : Approver
    {

        public override bool HandleRequest(int amount)
        {
            if (amount < 5)
            {
                Console.WriteLine("You can do it");
                return true;
            }
            else
            {
                return this.Next.HandleRequest(amount);
            }
        }
    }
}
