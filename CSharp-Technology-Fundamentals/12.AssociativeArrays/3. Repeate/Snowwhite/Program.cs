using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Snowwhite
{
    //Стъпка 1 - Създаваме клас с property за конкретния обект
    class Dwarf
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public BigInteger Physics { get; set; }
        public int ColorCount { get; set; }
        //С ColorCount ще броим колко джуджета имат сходен цвят и ще им задаваме стойност.
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            
            string input = string.Empty;
            //Стъпка 2 - създаваме списък в който ще пълним стойностите на джуджетата
            List<Dwarf> listOfDwarfs = new List<Dwarf>();

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                //Стъпка 3 - започваме да разпределяме данните от Input-a ни
                var data = input.Split(" <:> ").ToArray();

                string name = data[0];
                string color = data[1];
                BigInteger physics = BigInteger.Parse(data[2]);

                //Стъпка 4 - задаваме стойностите на текущото джудже, като тази за ColorCount не я взимаме все още
                Dwarf dwarf = new Dwarf();
                dwarf.Name = name;
                dwarf.Color = color;
                dwarf.Physics = physics;

                //Стъпка 5 - създаваме една променлива  alreadyExist която ще показва дали джуджето вече съществува
                bool alreadyExist = false;

                //Влизаме във for цикъла и обхождаме всички джуджета в него
                for (int i = 0; i < listOfDwarfs.Count; i++)
                {   //минаваме през всяко едно джудже като тук е важно ->
                    //ДЖУДЖЕ СЕ ДОСТЪПВА КАТО СЛОЖИШ INDEX ПРЕД НЕГО -> listOfDwarfs[i]
                    //АКО ИСКАШ ДА ДОСТЪПИШ СТОЙНОСТИТЕ ЗА КОНКРЕТНИЯ ОБЕКТ -> .Name .Color .Physics
                    if (listOfDwarfs[i].Name == name && listOfDwarfs[i].Color == color)
                    {   //правим проверка дали силата на конкретното джудже [i] е по-малка от силата която е подадена
                        if (listOfDwarfs[i].Physics < physics)
                        {   //заменяме стойността ако условието е вярно, и излизаме от цикъла.
                            listOfDwarfs[i].Physics = physics;
                            alreadyExist = true;
                            break;
                        }
                    }
                }

                //Ако джуджето вече съществува и стойността на силата му е заменена пропуска проверката, ако не влиза в нея
                if (alreadyExist == false)
                {
                    //Тук проверяваме какъв е броят на джуджетата от конкретния цвят и към този брой добавяме +1
                    //защото текущото джудже е от същия цвят и трябва да увеличим брояйт им.
                    int count = listOfDwarfs.Where(x => x.Color == color).Count() + 1;
                    //задаваме стойност на ColorCount и добавяме текущото джудже в списъка
                    dwarf.ColorCount = count;
                    listOfDwarfs.Add(dwarf);

                    //Тъй като джуджетата не са групирани в един общ списък трябва да обходим всички обекти които
                    //имат същия цвят както текущото джудже и ДА ИМ ПРИДАДЕМ БРОЙКАТА КОЯТО СМЕ НАМЕРИЛИ НА ГОРНИЯ
                    //РЕД 67 - 69
                    foreach (var item in listOfDwarfs.Where(x=>x.Color == color))
                    {
                        //НА ВСЯКО ДЖУДЖЕ СЪС СХОДЕН ЦВЯТ ЗАПИСВАМЕ ОБЩИЯ БРОЙ ОТ ДЖУДЖЕТА В ПРОПЪРТИТО МУ
                        item.ColorCount = count;
                    }
                }
                
            }

            //фИЛТРИРАМЕ ДЖУДЖЕТАТА НИЗХОДЯЩО ПО СИЛА И АКО ИМА ЕДНАКВИ СТОЙНОСТИ ТОГАВА ПО БРОЙ ОТ СХОДЕН ЦВЯТ
            foreach (var item in listOfDwarfs.OrderByDescending(z => z.Physics).ThenByDescending(z => z.ColorCount))
            {   //ПЕЧАТАМЕ
                Console.WriteLine($"({item.Color}) {item.Name} <-> {item.Physics}");
            }
        }

       
    }
}