using System;

namespace Inheritance_Generics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Тъй като сме задали че currCart очаква стрингове, не взимаме под внимание, че ShoppingCart e <T>, защото типа на данни в
            //StripingCart e дефиниран като string / class StringCart : ShoppingCart<string> /
            StringCart currCart = new StringCart();
            currCart.product = "Ivan";
            Console.WriteLine(currCart.product);

            //В този случай сме задали че GenericCart също като ShoppingCart e <T>, което означава че при дефиниране на инстанцията
            //трябва да зададем типа данни в които ще работят GenericCart и ShoppingCart+
            GenericCart<int> currGenCart = new GenericCart<int>();
            currGenCart.product = 123;
            Console.WriteLine(currGenCart.product);

            

        }
    }
}
