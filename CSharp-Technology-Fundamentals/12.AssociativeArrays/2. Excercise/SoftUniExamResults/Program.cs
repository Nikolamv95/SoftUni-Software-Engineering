using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] data = input
                                 .Split('-')
                                 .ToArray();

                string username = data[0];
                string language = data[1];

                if (language != "banned")
                {
                    int points = int.Parse(data[2]);

                    if (students.ContainsKey(username) == false)
                    {
                        students.Add(username, points);
                    }
                    else
                    {
                        int currResult = students[username];

                        if (currResult < points)
                        {
                            students[username] = points;
                        }
                    }

                    if (submissions.ContainsKey(language) == false)
                    {
                        submissions.Add(language, 1);
                    }
                    else
                    {
                        submissions[language] += 1;
                    }
                }
                else
                {
                    if (students.ContainsKey(username))
                    {
                        students.Remove(username);
                    }
                }
                
            }

            Console.WriteLine("Results:");
            foreach (var item in students.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(v => v.Value).ThenBy(k=>k.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
