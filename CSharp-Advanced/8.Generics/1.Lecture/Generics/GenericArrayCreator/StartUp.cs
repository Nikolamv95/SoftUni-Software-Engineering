using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] stringArr = ArrayCreator.Create(5, "Pesho");
            int[] intArr = ArrayCreator.Create(10, 33);
        }
    }
}
