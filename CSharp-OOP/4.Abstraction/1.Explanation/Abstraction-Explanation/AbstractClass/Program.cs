﻿using System;

namespace AbstractClass
{
    class Program
    {
         //Разликата м-у абстрактен клас и интерфейс е че абстрактния клас може да има имплементация вътре, той може да служи като интерфейс, да казва
         //какво трябва да има един клас който го е наследил, но може да има дефоултна имплементация (дефоутни методи) и не трябва да може да се инстанцира.
         //С други думи абстрактния клас може да има модифайъри(private, protected И т.нн) докато интерфефйса не всичко е публик
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
