using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    class TestClass<T>
    {
        private T[] array = new T[100];

        //В този случай V наследява Т и двете стойности стойности ще бъдат от един и същи тип
        // T е масива а V e стойността. Щом V наследява T, значи V наследяват типа данни (string, int и т.н) на Т
        public void Add<V>(V item) where V : T
        {
            array[0] = item;
        
        }

        //public void MyMethod<V>(V item) where T : BaseClass, new() // така Т може да наследи даден клас и интерфейс или празен конструктор
        //                                                           // не може да наследи 2 или 3 различни класа или Class и Struct
        //{
        //    array[0] = item;

        //}
    }
}
