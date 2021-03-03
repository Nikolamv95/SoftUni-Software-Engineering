using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackAndQueues
{
    public class CustomList : IEnumerable<int>
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        //Create a functionality which allowes to acces the items in the collection with index [i]
        public int this[int index]//Indexsation
        {
            get 
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];               
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public void Add(int items)
        {
            //Добавяме нови елементи към колекцията
            if (this.Count== this.items.Length)
            {
                this.Resize();
            }

            //В колекцията добавяме стойност на текущия Count
            //ако имаме 1 елемент в колекцията каунт е 1
            //но индекса на елемента е 0, така че на 1 добавяме новата стойност
            this.items[this.Count] = items;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            //Взимаме стойността която се намира на конкретния индекс
            int value = this.items[index];

            //Проверяваме дали големината на текущия масив е по-малка или равна
            //на големанината на текущия масив / 4
            //5 (колко елемента от колекцията са запълнини) /
            // 20 / 4 = 5 (20 е големината на колекцията) ние имаме 5 стойности в нея и 15 които можем да добавим още
            //ако условието е вярно влизаме в иф проверката и разделяме / 2 дължината на колекцията и от 20 тя става 10 с 5 стойности вътре
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            //Преместваме всички стойности от подадения индекс с една напред и така ако имаме списък
            // 5 4 3 2 1 и искаме да премахнем 4, то върху него ще запише 3 върху 3-> 2 и т.н
            // 5 3 2 1 1 така ще излгежда списъка после
            this.Shift(index);
            this.Count--;
            this.items[this.Count] = 0;
            //Махаме от count 1 еденица
            

            return value;
        }

        public bool Contains(int value)
        {
            bool isFound = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (value == this.items[i])
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        public void Swap(int firstElement, int secondElement)
        {
            if (firstElement >= this.Count || secondElement >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }


            int valueFirst = this.items[firstElement];
            int valueSecond = this.items[secondElement];
            this.items[firstElement] = valueSecond;
            this.items[secondElement] = valueFirst; 
        }

        public void Insert(int index, int item)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = 0;
            Count++;

            this.ShiftToRight(index);
            this.items[index] = item;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void ShiftToRight(int index)
        {
            //int count = this.Count;
            //for (int i = count - 1 ; count >= index; count -= 1)
            //{
            //    int currValue = this.items[count];
            //    this.items[count + 1] = currValue;
            //}

            for (int i = this.Count-1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i <this.Count-1 ; i++)
            {
                //Взимаме стойността която трябва да презапишем
                int currValue = this.items[i + 1];
                //и я записваме на предходната
                this.items[i] = currValue;
            }
        }

        private void Shrink()
        {
            //Take the length of the currColection / 2
            int newLength = this.items.Length / 2;
            //Създаваме нов масив с дължината на стария / 2
            int[] temp = new int[newLength];

            //копираме данните от предходния масив в новия (temp) с дължината на старуя
            Array.Copy(this.items, temp, this.Count);
            //записваме новия масив върху стария
            this.items = temp;
        }

        private void Resize()
        {

            int newLength = this.items.Length * 2;
            int[] temp = new int[newLength];

            for (int i = 0; i < this.items.Length; i++)
            {
                temp[i] = this.items[i];
            }

            //Or we can conpy the previous array with this Arra.Copy function
            //Array.Copy(this.items, temp, this.items.Length);

            this.items = temp;


        }

        public IEnumerator<int> GetEnumerator()
        {
            int currValue = this.items[0];

            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
