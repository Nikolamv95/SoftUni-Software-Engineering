using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesExample
{
    class Person
    {
        //Това е автоматично пропърти (touch point) което ни дава
        //правото да достъпваме и записваме данние в Age. Това е съкратен запис на
        // -> public int Age { get; set; }

        //Цял запис
        private int age; // -> това ни е setter
        public int Age // -> това ни е getter
        {
            //Тук вътре можем да контролираме какви данни точно да върне
            get
            {
                return age;
            }
            //И при какви условия може да запише данни (value) в стойността на age
            //Ако set e privet set то стойността му ще може да бъде записана само тук, отвън НЕ
            set 
            {

                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Ivalid Age - Try again");
                }

                age = value;
            }
        }
    }
}
