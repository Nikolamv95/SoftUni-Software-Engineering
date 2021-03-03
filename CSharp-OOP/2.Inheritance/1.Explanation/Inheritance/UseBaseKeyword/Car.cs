using System;
using System.Collections.Generic;
using System.Text;

namespace UseBaseKeyword
{
    class Car : Vehicle
    {
        //Всеки един наследник може да достъпи пропърти на основния клас с ключовата дума Base
        public void Drive()
        {                                    //base.Пропъртито
            Console.WriteLine($"Max speed is {base.MaxSpeed}");
            //Също така може да се достъпи без да се пише думичката base, а само името на пропъртито
            Console.WriteLine($"Max speed is {MaxSpeed}");
        }
    }
}
