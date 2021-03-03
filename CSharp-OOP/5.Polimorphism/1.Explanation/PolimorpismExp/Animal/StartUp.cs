using System;
using System.Collections.Generic;

namespace Animal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Snake();
            if (animal is Snake)
            {
                Console.WriteLine("isSnake");
            }
            Animal animal2 = new Cat();
            Animal animal3 = new Dog();
            Animal animal4 = new GoldenRetriver(); //GolderR inherited clas Dog which clas inherited Animal, so GR is child class of Animal

            Human snakeHater = new Human(animal);
            Human catLover = new Human(animal2);
            Human dogLover = new Human(animal3);
            Human goldenRet = new Human(animal4);//Human keeps as a property Animal so he can receive all classes which inherited Animal

            List<Human> humans = new List<Human>();
            humans.Add(snakeHater);
            humans.Add(catLover);
            humans.Add(dogLover);
            humans.Add(goldenRet);

            foreach (var item in humans)
            {
                item.Feed();
                item.PutToSleep();
            }
           
        }
    }
}
