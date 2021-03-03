using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Generics
{   //Не може да сложиш Т трябва да подадеш тип данни в ShoppingCart<>
    //За да направим ShoppingCart<Т> трябва и StripingCart<T> и в мейн метода да дефинираме какъв тип данни ще получат String,int и т.н
    class StringCart : ShoppingCart<string> 
    {
    }
}
