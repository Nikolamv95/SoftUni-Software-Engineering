using System;
using System.Collections.Generic;
using System.Linq;

namespace legendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - създаваме 2 речника в които ще държим keyMaterials и JunkMaterials
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            //Добавяме си keyMaterials дадени по условие
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            bool isCreated = false;

            //Стъпка 2 - създаваме While Цикъл
            while (isCreated == false)
            {
                //Въвеждаме инпута
                string[] input = Console.ReadLine().Split();

                //Стъпка 3 - с for цикъл разпределяме материалите по списъците
                //Особенното е че цикъле прескача през 2 идекса 0,2,4,6 и т.н
                //защото в индекс i се намира quantiti а в индекс i+1 се намира material

                for (int i = 0; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    //Разпределяме материакуте ба Key & Junk. Първо влизаме в Key materials а в else влизаме в Junk
                    if (material == "motes" || material == "shards" || material == "fragments")
                    {
                        //Тъй като вече са добавени материалите в началото на задачата тук добавяме само количеството
                        keyMaterials[material] += quantity;

                        //Правим проверка дали текущия материал вече не е с над 250 количество
                        if (keyMaterials[material] >= 250)
                        {
                            //Ако е с над 250 изваждаме от текущия материал 250
                            keyMaterials[material] -= 250;

                            //Правим проверка кой е конкретния материал и печатаме че сме го изработили
                            switch (material)
                            {
                                case "motes":
                                    Console.WriteLine($"Dragonwrath obtained!");
                                    break;
                                case "shards":
                                    Console.WriteLine($"Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine($"Valanyr obtained!");
                                    break;
                            }

                            //даваме стойност true че сме създали материала и прекъсваме for цикъла
                            isCreated = true;
                            break;
                        }
                    }
                    else
                    {
                        //Правим проверка дали junk материала вече съществува, ако не съществува
                        //добавяме стойностите му, ако съществува добавяме само количеството
                        if (junkMaterials.ContainsKey(material) == false)
                        {
                            junkMaterials.Add(material, quantity);
                        }
                        else
                        {
                            junkMaterials[material] += quantity;
                        }
                    }
                }
            }

            //Стъпка 4 - създаваме нов списък в който филтрираме и сортираме как трябва да се
            //принтират материалите. С ордер им даваме сортировка 1, а с thenBy им даваме сортировка 2
            //в случай че в order има 2 материала с еднакви стойности Value.
            Dictionary<string, int> filKeyMaterials = keyMaterials
                                                        .OrderByDescending(v => v.Value)
                                                        .ThenBy(k => k.Key)
                                                        .ToDictionary(k => k.Key, v => v.Value);

            //Принтираме filKeyMaterials
            foreach (var item in filKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            //Сортираме по азбучен ред Junk и ги принтираме
            foreach (var item in junkMaterials.OrderBy(k=> k.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
