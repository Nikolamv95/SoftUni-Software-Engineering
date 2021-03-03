using System;
using System.Diagnostics.CodeAnalysis;


//АКО ИСКАМЕ ДА СЪЗДАВАМЕ МЕТОДИ КОИТО ОПЕРИРАТ С ДАННИТЕ КОИТО СЕ СЪДЪРЖАТ В BOX<T> ТО ТЕЗИЕ МЕТОДИ ТРЯБВА ДА СЕ ЗАПИШАТ В BOX.CS
namespace GenericCountMethodStrings
{
    //ЗА ДА МОЖЕМ ДА СРАВНЯВАМЕ 2 НЕИЗВЕСТНИ СТОЙНОСТИ <Т> ТРЯБВА ДА КАЖЕМ НА КЛАСА ЧЕ BOX<T> В КОЙТО T : E ICOMPARABLE(СРАВНИМО)
    //С ДРУГИ ДУМИ BOX<T> ТОВА <Т> МОЖЕ ДА БЪДЕ СРАВНИМО И ПО ТОЗИ НАЧИН ОТКЛЮЧВАМЕ ФУНКЦИИТЕ КАТО COMPARETO
    public class Box<T> where T : IComparable
    {
        //2 - Създаваме конструктор който записва стойността подадена във Value 
        public Box(T value)
        {
            this.Value = value;
        }

        //1 - Създаваме си пропърти за Value
        public T Value { get; set; }

        //4 - Създаваме Custom метод който взима стойността на данни от тип Box<T> и ги сравнява дали текущата
        //е по-голяма от тази с която трябва да я сравним
        public int MyCompareTo(Box<T> valueToCompare)
        {
            //Текущата стойност от списъка this.Value я сравняваме с тази която ни е подадена (valueToCompare.Value)
            //Тук викаме Метода CompareTo, който го получихме от where T : IComparable
            int result = this.Value.CompareTo(valueToCompare.Value);
            //Ако резултата е 1 текущата стойност е по-голяма от valueToCompare.Value, 0 равни, -1 по-малка
            return result; // Връща 1, 0 или -1
        }

        //5 - Създаваме Custom метод който взима стойността на данни от тип Box<T> и ги сравнява дали текущата
        //е по-голяма от тази с която трябва да я сравним
        public bool IsBigger(Box<T> valueToCompare)
        {
            //Текущата стойност от списъка this.Value я сравняваме с тази която ни е подадена (valueToCompare.Value)
            //Тук викаме Метода CompareTo, който го получихме от where T : IComparable
            int result = this.Value.CompareTo(valueToCompare.Value);
            //Ако резултата е 1 текущата стойност е по-голяма от valueToCompare.Value, 0 равни, -1 по-малка
            return result > 0; //Връща True или False
        }

        //3 - създаваме метод ToString който печата стойността и типа на текущото Value
        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }

    }
}
