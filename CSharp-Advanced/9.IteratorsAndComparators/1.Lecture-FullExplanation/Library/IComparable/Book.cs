using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;


namespace IComparable
{
    public class Book : IComparable<Book> //Този интерфейс ни дава правото да сравняваме 2 обекта и техните стойности
        //СЪЩО ТАКА ICOMPARABLE НИ ПОЗВОЛЯВА ДА ИЗПОЛЗВАМЕ СТРУКТУРИ КАТО SORTEDSET И СЪОТВЕТНО В ТЯХ ДА НЕ СЕ ДОБАВЯТ ЕДНАКВИ ЕЛЕМЕНТИ, А ДА БЪДАТ САМО УНИКАЛНИ
    {
        public Book()
        {

        }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        //Винаги подаваме стойност която ще сравни
        public int CompareTo(Book other)
        {
            //ако е ТЕКУЩАТА СТОЙНОСТ по голяма от ДАДЕНАТА OTHER.YEAR
            if (other.Year < this.Year)
            {
                return 1;
            }
            else if (other.Year == this.Year)
            {//ако е равна на текущата връщаме 0
                return 0;
            }
            else
            {//ако е по малка от текущата връщаме -1
                return -1;
            }
        }
    }
}
