using System;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                var data = command.Split(' ').ToArray();
                string operation = data[0];

                switch (operation)
                {
                    //Take Only odd indexes
                    case "TakeOdd":
                        string currPassword = string.Empty;
                        for (int i = 0; i < inputPassword.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                currPassword += inputPassword[i];
                            }
                        }
                        inputPassword = currPassword;
                        Console.WriteLine(inputPassword);
                        break;
                    //Remove
                    case "Cut":
                        int startIndex = int.Parse(data[1]);
                        int length = int.Parse(data[2]);
                        inputPassword= inputPassword.Remove(startIndex, length);
                        Console.WriteLine(inputPassword);
                        break;
                    //Replace
                    case "Substitute":
                        string currChar = data[1];
                        string replaceChar = data[2];

                        if (inputPassword.Contains(currChar))
                        {
                            inputPassword = inputPassword.Replace(currChar, replaceChar);
                            Console.WriteLine(inputPassword);
                        }

                        else
                        {
                            Console.WriteLine($"Nothing to replace!");
                        }
                        break;
                }
            }
            Console.WriteLine($"Your password is: {inputPassword}");
        }
    }
}
