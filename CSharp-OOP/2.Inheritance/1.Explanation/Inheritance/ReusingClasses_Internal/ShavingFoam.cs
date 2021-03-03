using System;
using System.Collections.Generic;
using System.Text;

namespace ReusingClasses_Internal
{
    class ShavingFoam : Product
    {
        public bool CanBuy(double money)
        {
            return money > this.Price;
        }
    }
}
