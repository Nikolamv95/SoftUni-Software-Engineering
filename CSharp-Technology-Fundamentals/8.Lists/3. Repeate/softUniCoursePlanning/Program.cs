using System;
using System.Collections.Generic;
using System.Linq;

namespace softUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                                    .Split(", ")
                                    .ToList();

            string commands = Console.ReadLine();

            while (commands != "course start")
            {
                string[] commandsToDo = commands
                                        .Split(':');

               lessons = CommandsToDo(lessons, commandsToDo);

               commands = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }
        }

        private static List<string> CommandsToDo(List<string> lessons, string[] commandsToDo)
        {
            switch (commandsToDo[0])
            {
                case "Add":
                    lessons = Add(commandsToDo, lessons);
                    break;     
                case "Insert":
                    lessons = Insert(commandsToDo, lessons);
                    break;
                case "Remove":
                    lessons = Remove(commandsToDo, lessons);
                    break;
                case "Swap":
                    lessons = Swap(commandsToDo, lessons);
                    break;
                case "Exercise":
                    lessons = Exercise(commandsToDo, lessons);
                    break;
            }
            return lessons;
        }

        private static List<string> Swap(string[] commandsToDo, List<string> lessons)
        {
            string firstLesson = commandsToDo[1];
            string secondLesson = commandsToDo[2];

            bool firstLessonExist = lessons.Contains(firstLesson);
            bool secondLessonExist = lessons.Contains(secondLesson);

            if (firstLessonExist == true && secondLessonExist == true)
            {
                int indexFirstLesson = lessons.IndexOf(firstLesson);
                int indexSecondLesson = lessons.IndexOf(secondLesson);

                lessons.Insert(indexSecondLesson, firstLesson);
                lessons.RemoveAt(indexSecondLesson + 1);

                lessons.Insert(indexFirstLesson, secondLesson);
                lessons.RemoveAt(indexFirstLesson + 1);
                
                string firstExerciseToCheck = $"{commandsToDo[1]}-Exercise";
                string secondExerciseToCheck = $"{commandsToDo[2]}-Exercise";

                bool firstExerciseExist = lessons.Contains(firstExerciseToCheck);
                bool secondExerciseExist = lessons.Contains(secondExerciseToCheck);


                if (firstExerciseExist == true && secondExerciseExist == true)
                {
                    int indexfirstExercise = lessons.IndexOf(firstExerciseToCheck);
                    int indexsecondExercise = lessons.IndexOf(secondExerciseToCheck);

                    lessons.Insert(indexfirstExercise, secondExerciseToCheck);
                    lessons.Insert(indexsecondExercise, firstExerciseToCheck);
                }
                else if (firstExerciseExist == true && secondExerciseExist == false)
                {
                    int indexFirstExercise = lessons.IndexOf(firstExerciseToCheck);
                    lessons.Insert(indexSecondLesson+1, firstExerciseToCheck);
                    lessons.RemoveAt(indexFirstExercise + 1);

                }
                else if (firstExerciseExist == false && secondExerciseExist == true)
                {
                    int indexSecondExercise = lessons.IndexOf(secondExerciseToCheck);
                    lessons.Insert(indexFirstLesson+1, secondExerciseToCheck);
                    lessons.RemoveAt(indexSecondExercise + 1);
                }
            }
            return lessons;
        }

        private static List<string> Exercise(string[] commandsToDo, List<string> lessons)
        {
            string lessonToCheck = commandsToDo[1];
            string exerciseToCheck = $"{commandsToDo[1]}-Exercise";

            bool lessonExist = lessons.Contains(lessonToCheck);
            bool exerciseExist = lessons.Contains(exerciseToCheck);

            if (lessonExist == true && exerciseExist == false)
            {
                int index = lessons.IndexOf(lessonToCheck);
                lessons.Insert(index + 1, exerciseToCheck);
            }
            else if (lessonExist == false && exerciseExist == false)
            {
                lessons.Add(lessonToCheck);
                lessons.Add(exerciseToCheck);
            }

            return lessons;
        }

        private static List<string> Remove(string[] commandsToDo, List<string> lessons)
        {
            bool exist = lessons.Contains(commandsToDo[1]);

            if (exist == true)
            {
                string lessonToRemove = commandsToDo[1];
                lessons.Remove(lessonToRemove);

                string removeExercise = lessonToRemove + "-Exercise";
                bool existExercise = lessons.Contains(removeExercise);
                if (existExercise == true)
                {
                    lessons.Remove(removeExercise);
                }
            }

            return lessons;
        }

        private static List<string> Insert(string[] commandsToDo, List<string> lessons)
        {
            bool exist = lessons.Contains(commandsToDo[1]);

            if (exist == false)
            {
                string lessonToInsert = commandsToDo[1];
                int index = int.Parse(commandsToDo[2]);
                lessons.Insert(index, lessonToInsert);
            }
            return lessons;
        }

        private static List<string> Add(string[] commandsToDo, List<string> lessons)
        {
            bool exist = lessons.Contains(commandsToDo[1]);

            if (exist == false)
            {
                lessons.Add(commandsToDo[1]);
            }

            return lessons;
        }
    }
}
