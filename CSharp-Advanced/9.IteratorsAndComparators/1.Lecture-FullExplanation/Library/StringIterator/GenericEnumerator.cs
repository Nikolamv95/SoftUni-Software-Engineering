using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringIterator
{
    public class GenericEnumerator : IEnumerator<string>
    {
        //Стъпка 4 - създаваме пропърти за List от стрингов и начален индекс -1 
        //(-1 е защото няма никакви данни и когато влезне първата данна индекса ще стане 0)
        private readonly List<string> list;
        private int currIndex = -1;

        //Стъпка 5 - влизаме в констркуктора и в this.list записваме листа който ни се подава от StringLIstIEnumerable
        public GenericEnumerator(List<string> list)
        {
            this.list = list;
        }

        //Стъпка 8 - var item реално се връща и взима текущата стойност на колекцията с конретния индекс
        public string Current => list[currIndex];

        object IEnumerator.Current => list[currIndex];

        public void Dispose()
        {
            
        }

        //Стъпка 7 от main метода вече сме влезнали във форийча и in ни препраща към метода в класа GenericEnumerator MoveNext()
        public bool MoveNext()
        {
            //Тъй като в колекцията има стойности увеличаваме индекса от -1 на 0 и правим проверка дали текущия индекс е по-малък от големината на списъка
            //ако е връщаме True, ако не връщаме False и in не преминава към var item;
            currIndex++;
            return currIndex < list.Count;
        }

        public void Reset()
        {
            currIndex = -1;
        }
    }
}
