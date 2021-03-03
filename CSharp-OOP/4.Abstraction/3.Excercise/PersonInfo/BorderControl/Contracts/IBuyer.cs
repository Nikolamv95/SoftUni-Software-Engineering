using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    interface IBuyer
    {
        public int Food { get;}

        public void BuyFood();
    }
}
