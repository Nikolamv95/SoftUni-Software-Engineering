using System;
using System.Collections.Generic;
using System.Text;

namespace ReusingClasses_Internal
{
    //Всички пропъртита се наследяват от класа наследник, но имат рестрикции кое къде може да се прочете и достъпи
    public class Product
    {
        //Достъпно е навсякъде в програмата
        public int Id { get; set; }
        //Може да се достъпи само от класа наследник, но в StartUp не можеш да го прочетеш
        protected double Price{ get; set; }
        //Достъпно е само за проекта ReusingClasses_Internal
        internal string Name { get; set; }
    }
}
