using System;

namespace verbatimString
{
    class Program
    {
        static void Main(string[] args)
        {
            // знакът \ e символ за начало на ескейп последователност. Ако искаме да се отпечата символа \ трябва
            // да добавим още един \ пред него -> \\
            string file = "C:\\Windows\\win.ini";
            Console.WriteLine(file);
             
            // знакът @ преди началото на стринга премахва функцията за ескеп последователност и можем да напишем
            // само един знак \
            string file2 = @"C:\Windows\win.ini";
            Console.WriteLine(file2);

            // Проблемът при този символ @ е ако искаме да поставим в стринга кавички "". Тук както по-горе трябва
            // да поставим още 2 кавички за да може да зачете символа и да не счупи кода
            string file3 = @"C:\Windows\w"in".ini";
            string file4 = @"C:\Windows\w""in"".ini";
            Console.WriteLine(file4);

            //Verbative string ни позволява да използваме и Interpolations {variable}. Трябва да напишем и $@ отпред
            string file5 = $@"C:\Windows\{file}w""in"".ini";
            Console.WriteLine(file5);

        }
    }
}
