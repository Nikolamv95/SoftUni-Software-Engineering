using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class CTO : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount < 500)
            {
                Console.WriteLine("CTO procceed");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
