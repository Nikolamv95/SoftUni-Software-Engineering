using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - Създаваме си лист в който ще напълним уроците
            List<string> list = Console.ReadLine()
                            .Split(", ")
                            .ToList();

            //Стъпка 2 - Създаваме си празен input
            string input = string.Empty;

            //Стъпка 3 - Създавме While цикъл, който ще проверява какви са командите.
            //Вътре в While цикъла дефинираме командите които ще пишем.
            while ((input = Console.ReadLine()) != "course start")
            {
                //Стъпка 4 - създаваме масив, който разбива input-a и му премахва : за да раздели stringa който сме получили
                string[] command = input.Split(":");
                //Стъпка 5 - създаваме си метод в който ще извършваме основните команди
                list = SoftUniCoursePlanning(list, command);
            }

            //Стъпка 7 - Последна стъпка, да отпечатаме List-a след операциите
            for (int i = 0; i < list.Count; i++)
            {
                //За да отпечатаме листа с цифра пред всяка стойност слагаме i+1 -> защото започваме от първа позиция
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }

        //Основен медот в който влизат данните от Main метода и ги разпределя спрямо операциите които
        //трябва да се извършат
        static List<string> SoftUniCoursePlanning(List<string> list, string [] command)
        {
            //Стъпка 6 - със switch проверяваме каква команда ще трябва да извършим, като за всяка команда
            //правим нов метод към който се подават листа и масива с команди + стойностите в него string [] command 
            switch (command[0])
            {
                case "Add": 
                    list = Add(list, command); 
                    break;
                case "Insert": 
                    list = Insert(list, command); 
                    break;
                case "Remove": 
                    list = Remove(list, command); 
                    break;
                case "Swap": 
                    list = Swap(list, command); 
                    break;
                case "Exercise": 
                    list = Exercise(list, command); 
                    break;
                default:
                    break;
            }

            //След всяка операция връща към Lista в main method новите данни
            return list;
        }

        //Вкарване ново упражнение - Insert after the Exercise
        static List<string> Exercise(List<string> list, string[] command)
        {            
            // Стъпка 1 - взимаме стойността на масива, която съдържа името на урока
            string lessonTitle = command[1];
            // Стъпка 2 - проверяваме дали листа съдържа конкретния урок и НЕ съдържа упражнение
            if (list.Contains(lessonTitle) && !list.Contains(lessonTitle + "-Exercise"))
            {
                //Стъпка 3 - влизаме и взимаме индекса на урока у след това добавяме упражнението след него
                //index + 1, името на урока + Exercise
                int index = list.IndexOf(lessonTitle);
                list.Insert(index + 1, lessonTitle + "-Exercise");
            }
            //Ако урока не съществува добавяме и урока и упражнението на последно място
            else if (!list.Contains(lessonTitle))
            {
                list.Add(lessonTitle);
                list.Add(lessonTitle + "-Exercise");
            }

            return list;
        }


        //ОСОБЕННО ВНИМАНИЕ - Разменяме урок + упражнение с друг урок + упражнение
        static List<string> Swap(List<string> list, string[] command)
        {
            //Стъпка 1 - Взимаме заглавието на Урок 1 и Урпк 2
            string lessonTitle1 = command[1];
            string lessonTitle2 = command[2];
            //Стъпка 2 - Взимаме индексите на които се намират Урок1 и Урок2
            int index1 = list.IndexOf(lessonTitle1);
            int index2 = list.IndexOf(lessonTitle2);

            //Стъпка 3 - Проверяваме дали Урок1 и Урок2 съществуват
            if (list.Contains(lessonTitle1) && list.Contains(lessonTitle2))
            {
                //Разменяме заглавията на двата урока. Като Урок1 с индекс Х 
                //вече е равен на Урок2 с индекс Х
                list[index1] = list[index2]; //Промяна
                list[index2] = lessonTitle1;
            }
            //Стъпка 4 - Правим още едн задължителна проверка -> Дали Урок1 съществува в листа ни
            //заедно с упражнение си.
            if (list.Contains(list[index1]) && list.Contains(lessonTitle1 + "-Exercise"))
            {
                //Стъпка 5 - взимаме индекса на самия урок който вече съществува.
                //Изтриваме от списъка упражнението от този урок
                //и добавяме упражнението веднага след урока -> index1 + 1
                index1 = list.IndexOf(lessonTitle1);
                list.Remove(lessonTitle1 + "-Exercise");
                list.Insert(index1 + 1, lessonTitle1 + "-Exercise");
            }
            if (list.Contains(list[index2]) && list.Contains(lessonTitle2 + "-Exercise")) // Промяна
            {
                //Стъпка 6 - взимаме индекса на самия урок който вече съществува.
                //Изтриваме от списъка упражнението от този урок
                //и добавяме упражнението веднага след урока -> index2 + 1
                index2 = list.IndexOf(lessonTitle2);
                list.Remove(lessonTitle2 + "-Exercise");
                list.Insert(index2 + 1, lessonTitle2 + "-Exercise");
            }
            //Стъпка 7 -> Връщаме обработения лист
            return list;
        }

        //Изтриваме урок - Remove
        static List<string> Remove(List<string> list, string[] command)
        {
            // Стъпка 1 - взимаме стойността на масива, която съдържа името на урока
            string lessonTitle = command[1];
            //Стъпка 2 - приверяваме дали урока съществува и съответно го махаме 
            //!Както! и упражнението му
            if (list.Contains(lessonTitle))
            {
                list.Remove(lessonTitle);
            }
            else if (list.Contains(lessonTitle + "-Exercise"))
            {
                list.Remove(lessonTitle + "-Exercise");
            }
            //Стъпка 3 - връщаме стойността на листа
            return list;
        }

        //Добавяме на конкретна позиция урок - Insert
        static List<string> Insert(List<string> list, string[] command)
        {
            //Стъпка 1 - взимаме името на урока и индекса на който трябва да го сложим
            string lessonTitle = command[1];
            int index = int.Parse(command[2]);
            //Стъпка 2 - проверяваме дали индекса е по-малък от 0 и по-голям от дължината на листа.
            //ако е истина не записваме обработваме списъка и го връщаме както си е
            if (index < 0 || index >= list.Count)
            {
                return list;
            }
            else if (!list.Contains(lessonTitle))
            {
                //Ако горното условие е False проверяваме дали урока съществува, ако не съществува
                //влизаме и го инсъртваме спрямо условието index и lessonTitle
                list.Insert(index, lessonTitle);
            }
            //Стъпка 3 - връщаме обработения List
            return list;
        }
        
        //Добавяме урок на последна позиция - Add
        static List<string> Add(List<string> list, string[] command)
        {
            //Стъпка 1 - чрез стринг взимаме урока който се е записал в масива с индекс [1]
            string lessonTitle = command[1];
            //Стъпка 2 - проверяваме дали урока съществува, ако не съществува го добавяме на последно място.
            if (!list.Contains(lessonTitle))
            {
                //Стъпка 3 - добавяне на урока
                list.Add(lessonTitle);
            }
            //Стъпка 4 - връщаме стойността на обработения списък
            return list;
        }
    }
}