using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    //Ако искаме да създаваме собствени методи за сравняване на 2 обекта трябва да създадем нов клас BookComparator
    //който да възприема интерфейса : IComparer<T> Или IComparer<обект(Book)> и вече отдолу си дефинираме условията
    //НЕ ЗАБРАВЯМЕ ПРИ ЗАПИСВАНЕТО НА КНИГИТЕ В ЛИСА Library В КОНСТРУКТУРА ДА ЗАПИШЕМ
    //this.book.Sort(new BookComparator())
    //ПРИ ЗАПИСВАНЕТО НА ОБЕКТИТЕ В СПИСЪКА LIBRARY ЩЕ СЕ ПРЕМИНЕ ПРЕЗ МЕТОДА public int Compare(Book x, Book y)
    //И ЩЕ СЕ ЗАПИШАТ В LIBRARY ПО НАЧИНА ПО-КОЙТО СМЕ ЗАДАЛИ В МЕТОДА public int Compare(Book x, Book y)
    class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            //Сортираме заглавията по азбучен ред, ако има две заглавия с еднакви стойности
            //влизаме в if проверката и ги подреждаме в низходящ ред
            if (x.Title == y.Title)
            {
                return y.Year.CompareTo(x.Year); //descending order
                //Така написано условието по-голямата дата ще отиде пред по-малката. Това е OrderByDescending(x=>x.Year)
            }
            //Ако не влезе в if проверката сравни първото заглавие с второто и ако първото има по малка буква в азбуката
            //(А е по напред от Б), то сложи по-малката пред по-голямата
            return x.Title.CompareTo(y.Title); // ascending order
            //Така написано условието ако X е по-малко от Y, то X ще отиде преди Y 
        }
    }
}
