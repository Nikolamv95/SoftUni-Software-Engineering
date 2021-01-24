using System;
using System.Linq;
using System.Text;

namespace StringProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - Взимане на конкретна буква от стринг и превръщането и в char.
            string str = "Hello, C#";
            char ch = str[0];

            Console.WriteLine(ch);

            //2 - Превръщане на стринг в масив от char
            string strv2 = "Hello, C#";
            char [] chv2 = strv2.ToCharArray();

            Console.WriteLine(string.Join('-', chv2));

            //3 - Reverse string
            string input = "Hello, C#";
            Console.WriteLine(string.Join("", input.Reverse()));
            //или
            string inputV2 = "Hello, C#";
            char[] result = inputV2.Reverse().ToArray();
            Console.WriteLine(result);
            //или
            string inputV3 = "Hello, C#";
            char[] resultv3 = inputV2.ToCharArray();
            Console.WriteLine(string.Join("", resultv3.Reverse()));

            //4 - IndexOf - Връща индекса на първата буква от която започва първата срещната дума.
            //Vafla е на 11-ти индекс. Ако напишем дума която не съществува връща -1;
            string inputV4 = "Hello, C#, Vafla, Makaron, Vafla, Usmivka";
            Console.WriteLine(inputV4.IndexOf("Vafla"));

            //5 - LastIndexOf - Връща индекса на първата буква от която започва последната срещната дума.
            //последната дума Vafla е на 27-ми индекс. Ако напишем дума която не съществува връща -1;
            string inputV5 = "Hello, C#, Vafla, Makaron, Vafla, Usmivka";
            Console.WriteLine(inputV5.LastIndexOf("Vafla"));

            //6 - Substring (int startIndex, int length) - Чрез този метод печатаме конкретни символи от
            //дадения стринг, като задължително слагаме началния индекс и дължината от символи които трябва
            //да отпечатаме. Ако не сложим дължина ще отпечата всичко след началния индекс
            string inputV6 = "Hello, C#, Vafla, Makaron, Vafla, Usmivka";
            int firstIndexVafla = inputV6.IndexOf("Vafla");
            Console.WriteLine(inputV6.Substring(firstIndexVafla, 5));
            Console.WriteLine(inputV6.Substring(firstIndexVafla));

            //7 - Contains - Проверява дали конкретната поредица от символи се съдържа в стринга и връща
            //булев резултат. За да нямаме проблеми с главни и малки букви превеждаме стринга и проверката
            //към ToLower or ToUpper
            string inputV7 = "Hello, C#, Vafla, Makaron, Vafla, Usmivka";
            Console.WriteLine(inputV7.ToLower().Contains("vafla".ToLower()));
            //или
            Console.WriteLine(inputV7.Contains("vafla", StringComparison.InvariantCultureIgnoreCase));

            //8 - Split - премахва разделителите между думите. Винаги си използвай StringSplitOptions.
            //Също така можеш да си дефинираш всички разделите в един масив и да подадеш масива като ст-ст.
            char[] separators = new char[] { ' ', ',', '.' };
            string text = "Hello, I am John";
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //9 - Replace (match, replacement) - Заменя всички места където се среща даен символ/израз.
            string textV2 = "Hello, I am John and John no John only John";
            textV2 = textV2.Replace("John", "Nikola");
            Console.WriteLine(textV2);

            //10 - StringBuilder - инстанциране -> StringBuilder sb = new StringBuilder ();
            StringBuilder sb = new StringBuilder(); 
            //Методите на StringBuilder се достъпват след като напишем името му sb. и сложим точка след него.
            //sb.Append - добавя текст към текущия стринг на същия ред.
            //sb.Length - изписва дължината на самия стринг.
            //sb.Clear - премахва всички символи в стринга
            
            //В стринг билдера можем да достъпваме отново символите с индекс sb[число]
            //Insert - добавя стринг започващ от даден индекс sb.Insert(index 11, string Ivanov)

            //ВАЖНО!! превръщаме sb в стринг с метода sb.ToString() и след това печатаме
        }
    }
}
