using System;

namespace Abstraction_Explanation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            User user = new User();
            user.Money = 500;
            store.BuyProduct(new Shoe() { Price = 500 }, user); ;
            store.BuyProduct(new ToothBrush() { Price = 300 }, user);
            store.BuyProduct(new Microphone() { Price = 200 }, user);
        }
    }
}
