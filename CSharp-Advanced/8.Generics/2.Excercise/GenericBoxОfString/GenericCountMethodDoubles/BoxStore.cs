using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace GenericCountMethodStrings
{
    //1- СЪЗДАВАМЕ КОЛЕКЦИЯ ОТ КУТИИ, В КОЯТО ЩЕ СЕ ЗАПИСВАТ СТОЙНОСТИТЕ НА КУТИИТЕ ОТ BOX.CS
    //2- ПИШЕМ BOX<T> ЗАЩОТО НЕ ЗНАЕМ С КАКЪВ ТИП ДАННИ ЩЕ РАБОТИМ ОЩЕ
    //3- В ТОЗИ КЛАС BOXSTORE СЪЗДАВАМЕ МЕТОДИ КОИТО ПРАВЯТ ПРОМЕНИ ПО КОНФИГУРАЦИЯТА НА СПИСЪКА
    //4- ВАЖНО СЛЕД КАТО СМЕ ДЕФИНИРАЛИ ЧЕ THIS.BOXES ЩЕ Е СПИСЪК ТО НИЕ МОЖЕМ ДА ИЗПОЛЗВАМЕ ВСИЧКИ НЕГОВИ МЕТОДИ КАТО: ADD, REMOVEAT, REMOVE, INSER И Т.Н
    //5- ЗА ДА МОЖЕМ ДА СРАВНЯВАМЕ В СТОЙНОСТИ ОТ КОЛЕКЦИЯТА С ДАННИ BOX<T> КАЗВАМЕ НА КОЛЕКЦИЯТА ЧЕ <Т>(ПРЕВЕДЕНО BOX<T>) МОЖЕ ДА БЪБДЕ СРАВНЯВАНО
    public class BoxStore<T> where T : IComparable
    {
        //1 - създаваме privet пропърти което е List<Box<T>> -> Лист от Box с данни които ще разберем след това <Т>
        private List<Box<T>> boxes;

        //2 - създаваме празен конструктор, който при извикването на var myListOfBoxes = new List<Box<T>>() ще премине през
        //него и в this.Boxes ще създаде ПРАЗЕН ЛИСТ, В КОЙТО СЛЕД ТОВА ЩЕ СЕ ЗАПИСВАТ ДАННИ.
        //ЛОГИКА: 1- СЪЗДАВАМЕ КУТИЯ ОТ НЕЯСЕН ТИП ДАННИ BOX<T>, 2- СЪЗДАВАМЕ ЛИСТ В КОЙТО ЩЕ ПАЗИМ ТЕЗИ КУТИИ
        public BoxStore()
        {
            //boxes Вече става List от Боксове
            this.boxes = new List<Box<T>>();
        }

        //3 - Добавяме кутия на последно място в колекцията
        public void AddBox(Box<T> box)
        {
            //към текушия списък.добави(стойнността и пропъртитата на кутията която си записал в Box.cs)
            this.boxes.Add(box);
            //важно!! към текущия списък -> this.boxes. Add(това е метод на самия списък който сме използвали за тази цел.Той е предварително дефиниран
            //от майкрософт и не е къстъм метод който ние сме създали)
        }

        //4 - Промени местата на 2 кутии в колекцията
        public void SwapBoxes(int firstIndex, int secondIndex)
        {
            //Дефинираме типа на данни които се съдържат в списъка Box<T> и с this.boxes(firstIndex) достъпваме данните на конкретния индекс в колекцията
            Box<T> temp = this.boxes[firstIndex];
            //Дефинираме типа на данни които се съдържат в списъка Box<T> и с this.boxes(secondIndex) достъпваме данните на конкретния индекс в колекцията
            Box<T> temp2 = this.boxes[secondIndex];
            //След това на конкретния индекс дибавяме стойността която желаем и т.н
            this.boxes[secondIndex] = temp;
            this.boxes[firstIndex] = temp2;
        }

        //5 - Override метода ToString го използваме за да отпечатаме стойностите които се съдържат в колекцията this.boxes
        public override string ToString()
        {
            //Дефинираме стринг билдър
            StringBuilder sb = new StringBuilder();

            //Достъпваме this.boxes и прочитаме стойностите в него които са от тип Box<T>, може и var пред item
            foreach (Box<T> item in this.boxes)
            {
                //записваме стойността на item, като извикаме метода ToString, който отива в клас Box.cs (Номер 3) и отпечатва
                //данните на конкретния item
                sb.AppendLine(item.ToString());
            }

            //връща резултат и премахва празните простанства отзад
            return sb.ToString().Trim();
        }

        //6 - Чрез този метод ще изчислим колко от стойностите които имаме са по-големи от тази която ни е зададена (T valueToCompare)
        public int CountBiggerValues (T valueToCompare)
        {
            //За да можем да сравним подадената(прост тип данни (struct)) стойност с тези от списъка ни, трябва да превърнем ValueToCompare в данни от тип Box<T>. 
            //Това се случва като създадем нова променлива от тип Box<T>valueToCompareBox и в нея запишем данните на valueToCompare. 
            //Извикваме new Box<T> и подаваме на конструктора (valueToCompare), който ще запише стойността в this.Value = value;
            Box<T> valueToCompareBox = new Box<T>(valueToCompare);
            int result = 0;

            //Foreach-ваме през цялата колекция с this.boxes(взима текущата колекция)
            foreach (Box<T> item in this.boxes)
            {
                //върху текущия елемент от колекцията Item викаме наш метод IsBigger и му подаваме вече променената променлива (ValueToCompareBox)
                if (valueToCompareBox.IsLower(item))
                {
                    //ако резултата е true увеличаваме Result++;
                    result++;
                }
            }

            return result;
        }   
    }
}
