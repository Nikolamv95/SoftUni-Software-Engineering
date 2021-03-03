using System;

namespace ReusingClasses_Internal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ShavingFoam foam = new ShavingFoam();
            foam.Id = 5; //Public Product
            foam.CanBuy(10); //public ShavingFoam
            foam.Name = "BatPesho"; //Internal Product
            //foam.Price - не може да се прочете в main метода, но може да се достъпи 
            //и да се създадат методи със стойността му в ShavingFoam и Product
        }
    }
}
