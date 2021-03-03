using System;
using System.Collections.Generic;
using System.Linq;

namespace IComparable
{
    //ЗА ДА СОРТИРАМЕ ДАННИТЕ НА ДАДЕН КЛАС ИЛИ ДА ГИ СРАВНИМ С ДРУГ ВИНАГИ ТРЯБВА ДА ИМА 
    //ИМЕ НА КЛАСА BOOK : ICOMPARABLE И СЛЕД ТОВА РАЗПИШЕМ ИНТЕРФЕЙСА МУ
    class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            
            var list = MergeList(bookOne, bookTwo, bookThree);
            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item.Year);
            }
        }

        //Превръщаме масивите от книги чрез пармс в лист от книги и поради факта че Класа BOOKS E ICOMPARABEL ЩЕ МОЖЕМ ДА
        //СРАВНЯВАМЕ СТОЙНОСТИТЕ ВЪТРЕ В НЕГО И ДА ГИ СОРТИРАМЕ
        static List<T> MergeList<T>(params T[] books)
        {
            return books.ToList();
        }
    }
}
