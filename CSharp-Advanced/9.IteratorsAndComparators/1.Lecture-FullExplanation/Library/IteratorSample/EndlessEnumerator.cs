using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorSample
{
    class EndlessEnumerator : IEnumerator<int>
    {
        //създаваме property от топ Random с име Random
        private Random random;
        //Който от своя страна =random записва колекция от random числа и ги записва в GetEnumerator, който с метода MoveNext()
        //Всеки път връща ново число. Enumerator и IEnumerable работят заедно
        public EndlessEnumerator()
        {
            random = new Random();
        }

        //Двата Current еднакви и вършат едно и също действие. Различен синтаксис
        public int Current => random.Next();
        //public int Current { get; set; }

        object IEnumerator.Current => this.Current;

        //Този Enumerator имплеметира MoveNext, Reset, DIspose 
        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {

        }
    }
}
