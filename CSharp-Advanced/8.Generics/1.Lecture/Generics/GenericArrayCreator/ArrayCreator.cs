using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var newArray = new T[length];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = item;
            }

            return newArray;
        }

        //// Двете точки се четат като НАСЛЕДЯВА struct (само прости типове данни), class (само класове) //struct, class или празен конструктор
        //public static T Creator<T>() where T : new()// в този случай ако искаме да създадем нов обект от Т, трябва да сложим
        //                                            // : new() за да може компилатора да създаде празен конструктор и да го запише
        //                                            // върху Т
        //{
        //    return new T ();
        //}

        //public static T Creator2<T>() where T : BaseClass // BaseClass е просто име на клас или интерфейс, който вече сме създали с дадени
        //                                                  // пропъртита. По този начин ние казваме на Т да наследи нашия интерфейс или клас
        //                                                  // с всичките му пропъртита и функции създадени в него
        //{
        //    return new T();
        //}
    }
}
