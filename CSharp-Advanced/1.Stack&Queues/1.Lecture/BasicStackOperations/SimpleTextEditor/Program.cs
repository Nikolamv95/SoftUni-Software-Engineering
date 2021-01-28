namespace _10_Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> previousCommands = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "1":
                        //Вкарваме текущия текст в стака и взимаме стойността на новия, който в следващите,
                        //команди ще обработваме. Ако още първата команда е да добавим текст то в стека ще
                        //влезе празна стойност string.Empty.
                        previousCommands.Push(text);
                        text += commands[1];
                        break;
                    case "2":
                        //Вкарваме в стека текста който сме имали до този момент
                        previousCommands.Push(text);
                        //От текущия текст прочитаме символите които са не трябва да се изтрият, затова
                        //започваме от 0вия индекс и продължаваме до крата (цялата дължина - индексите за триене)
                        //Презаписваме стойността на string text с новата му стойност.
                        int indexToDell = int.Parse(commands[1]);
                        text = text.Substring(0, text.Length - indexToDell);
                        break;
                    case "3":
                        //Взимаме индекса и отпечатваме буквата от конкретния стринг;
                        int indexToRead = int.Parse(commands[1]);
                        Console.WriteLine(text[indexToRead- 1]);
                        break;
                    case "4":
                        //Извикваме последния стринг от стека и го премахваме. Така връщаме 1 операция назад
                        text = previousCommands.Pop();
                        break;
                }
            }
        }
    }
}