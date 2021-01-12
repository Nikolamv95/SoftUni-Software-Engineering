using System;
using System.Collections.Generic;
using System.Linq;

namespace students
{
    class Program
    {
        static void Main(string[] args)
        { //Стъпките в задачата са същите както в задача "students"!
            string input = Console.ReadLine();
            List<Student> listOfStudent = new List<Student>();

            while (input != "end")
            {
                string[] inputData = input
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string fullName = $"{inputData[0]} {inputData[1]}";


                string firsName = inputData[0];
                string lastName = inputData[1];
                string age = inputData[2];
                string homeTown = inputData[3];

                //Стъпка Х = правим проверка дали този човек вече съществува като първо и второ име.
                //за тази цел създаваме метод в if проверката. В този метод вкарваме listOfStudent, firsName, lastName
                //като този метод трябва да върне стойност False или Ture
                if (IsStudentExisting(listOfStudent, firsName, lastName))
                {
                    //След като сме намерили човека и сме установили че съществува създаваме метод който
                    //трябва да презапише студента с новите данни. Тук подаваме листа, първото име и фамилията
                    Student existingStudent = GetStudent(listOfStudent, firsName, lastName);

                    //ВАЖЕН ВЪПРОС КАК -> РЕАЛНО СЕ СЛУЧВА ПРЕЗАПИСВАНЕТО НА СТОЙНОСТТА???????????????????????????
                    existingStudent.FirstName = firsName;
                    existingStudent.LasttName = lastName;
                    existingStudent.Age = age;
                    existingStudent.Hometown = homeTown;
                }
                else
                {
                    Student student = new Student();

                    student.FirstName = firsName;
                    student.LasttName = lastName;
                    student.Age = age;
                    student.Hometown = homeTown;

                    listOfStudent.Add(student);
                }

                input = Console.ReadLine();
            }

            string cityCheck = Console.ReadLine();

            List<Student> filteredStudents = listOfStudent.Where(s => s.Hometown == cityCheck).ToList();

            foreach (Student print in filteredStudents)
            {
                Console.WriteLine($"{print.FirstName} {print.LasttName} is {print.Age} years old.");
            }
        }

        private static Student GetStudent(List<Student> listOfStudent, string firsName, string lastName)
        {
            //Тук дефинираме променлива от клас 
            Student existingStudent = null;

            //прочитаме целия слист като itemToCheck е от клас Student чрез него ще можем да достъпим свойствата на класа Student
            foreach (Student itemToCheck in listOfStudent)
            {   //Ако условието е true
                if (itemToCheck.FirstName == firsName && itemToCheck.LasttName == lastName)
                {   //влизаме и записваме стойностите на които itemToCheck е присвоил от листа. ВАЖНО itemToCheck присвоява всички свойства които
                    //могат да се достъпят от класа Student
                    existingStudent = itemToCheck;
                }
            }
            //Връщаме резултата
            return existingStudent;
        }

        private static bool IsStudentExisting(List<Student> listOfStudent, string firsName, string lastName)
        {
            //Стъпка 1 - проверяваме дали студента просъства с първо и фамилно име. Тук трябва да прочетем целия списък
            foreach (var itemToCheck in listOfStudent)
            {   //Ако видим че студента присъства влизаме в if проверката и връщаме веднага true
                if (itemToCheck.FirstName == firsName && itemToCheck.LasttName == lastName)
                {
                    return true;
                }
            }
            //Ако не съществува обхождаме цлия списък и връщаме false
            return false;
        }
    }
}
