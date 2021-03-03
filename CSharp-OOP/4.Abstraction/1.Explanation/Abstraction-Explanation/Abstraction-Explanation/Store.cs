using Abstraction_Explanation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction_Explanation
{
    class Store 
    {
        //Iprice е интерфейс и към него можем да подаваме всякакъв вид продукти, които са го наследили и имат price
        //Вътре в метода можем да използваме само и единствено цената му за конкретната цел 
        //В случая всички продукти които искаме могат да нследят абстракцията IPrice
        public void BuyProduct(IPrice product, User user)
        {
            decimal price = product.Price;

            if (user.Money < price)
            {
                throw new ArgumentException("You dont have enough money");
            }

            user.Money -= price;
        }
    }
}
