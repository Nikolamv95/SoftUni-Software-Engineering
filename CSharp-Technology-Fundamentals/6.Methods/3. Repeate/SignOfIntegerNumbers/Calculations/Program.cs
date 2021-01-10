using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().ToLower();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int result = CheckCommand(command, firstNum, secondNum);

            Console.WriteLine(result);
        }

        private static int CheckCommand(string command, int firstNum, int secondNum)
        {
            int result = 0;

            switch (command)
            {
                case "add":
                    result = firstNum + secondNum;
                    break;
                case "multiply":
                    result = firstNum * secondNum;
                    break;
                case "subtract":
                    result = firstNum - secondNum;
                    break;
                case "divide":
                    result = firstNum / secondNum;
                    break;
            }
            return result;
        }
    }
}
