using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringIterator
{
    /// <summary>
    /// IEnumerable записва колекцията която подаваме и данните в нея, докато Enumeratora ни дава функциалността да я ЧЕТЕМ и обхождаме. Също така
    /// Enumeratora пази състоянието до къде сме стигнали с обхождането на нашата колекция. IEnumerable<Т> и IEnumerator<T> са част от едно и също нещо
    /// </summary>
    class StringLIstIEnumerable : IEnumerable<string>
    {
        //Стъпка 2 - записваме предварително зададените стойности в масива
        private string[] names = { "Pesho", "Gosho", "TOsho" };

        public StringLIstIEnumerable()
        {

        }

        public StringLIstIEnumerable(string [] names)
        {
            this.names = names;
        }

        //Стъпка 3 - влизаме в GetEnumerator-a, инстанцираме класа new GenericEnumerator и му подаваме нашата колекция names.ToList()
        public IEnumerator<string> GetEnumerator()
        {
            //Стъпка  - връщаме се в GetEnumerator
            return new GenericEnumerator(names.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
