using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            //Взимаме входните данни
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int secondsPassCrossroad = int.Parse(Console.ReadLine());

            //Създаваме опашка в която ще вкарваме колите
            Queue<string> carsQueue = new Queue<string>();

            int counter = 0;

            while (true)
            {
                //Взимаме колата, която ще трябва да вкараме
                string car = Console.ReadLine();

                //Задаваме стойностите на greenLight и yellowLight
                int greenLights = greenLightSeconds;
                int yellowLights = secondsPassCrossroad;

                //Ако командата е End отпечатваме крайния резултат
                if (car == "END")
                {
                    Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                        $"{counter} total cars passed the crossroads.");
                    return;
                }

                //Ако командата е green започваме да пропускаме коли
                if (car == "green")
                {
                    //Въртим цикъла ако greenLight има секунди повече от 0 (надолу в цикъла премахваме от секундите на greenLight)
                    //и в същото време в опашката имаме коли
                    while (greenLights > 0 && carsQueue.Count != 0)
                    {
                        //Взимаме стойноста на първата кола и и изваждаме дължината от секундите за зелена светлина
                        string currCarr = carsQueue.Dequeue();
                        greenLights -= currCarr.Count();

                        //Ако greenLight е по-голяма от 0 колата е преминала и увеличаваме каунтъра
                        if (greenLights >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            //В противен случай към зелената светлина добавяме жълтата и проверяваме дали жълтата светлина е по-голяма от нула
                            //Тук може да е станало така че текущата кола да е с дължина 10 а зелената с останали секунди 2, така резултата на зелената
                            //е -8. Прибавяйкъ към -8 жълтата светлина целта е тя да надхвърли 0-та. Това означава че колата може да премине и увеличаваме
                            //каунтъра. Ако не може казва значи колата се е блъснала и влизаме в if проверката
                            yellowLights += greenLights;

                            if (yellowLights < 0)
                            {
                                //отпечатваме текущата кола и намираме символа като към текущата дължина добавим жълтата. Щом е влезнала тук програмата
                                //значи жълтата светлина има негативен резултат и тя от цялата дължина на колата ще извади стойността която държи. 10 - 2 = 8;
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                    $"{currCarr} was hit at" +
                                    $" {currCarr[currCarr.Length + yellowLights]}.");
                                return;
                            }

                            counter++;
                        }
                    }
                }
                //Ако не е green или end вкарваме колата в опашката
                else
                {
                    carsQueue.Enqueue(car);
                }
            }
        }
    }
}