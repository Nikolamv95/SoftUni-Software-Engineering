using System;

namespace onTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examTimeHour = int.Parse(Console.ReadLine());
            int examTimeMinutes = int.Parse(Console.ReadLine());
            int arivalTimeHour = int.Parse(Console.ReadLine());
            int arivalTimeMinutes = int.Parse(Console.ReadLine());

            // Превръщаме часовете в минути. Умножаваме часовете по 60 защото 1 час има 60 минути.
            // След това ги събираме с минутите и получаваме настоящия час в минути.
            int examInToMin = examTimeMinutes + (examTimeHour * 60);
            int arivalInToMin = arivalTimeMinutes + (arivalTimeHour * 60);

        //    if (ExamIntoMin < ArivalIntoMin)
        //    {
        //        var Time = ArivalIntoMin - ExamIntoMin;

        //        if (Time < 60)
        //        {
        //            Console.WriteLine("Late");
        //            Console.WriteLine("{0} minutes after the start", Time);
        //        }
        //        else if (Time >= 60)
        //        {
        //            if (Time % 60 < 10)
        //            {
        //                Console.WriteLine("Late");
        //                Console.WriteLine("{0}:0{1} hours after the start", Time / 60, Time % 60);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Late");
        //                Console.WriteLine("{0}:{1} hours after the start", Time / 60, Time % 60);
        //            }
        //        }
        //    }
        //    else if (ExamIntoMin > ArivalIntoMin)
        //    {
        //        var Time = ExamIntoMin - ArivalIntoMin;

        //        if (ExamIntoMin == ArivalIntoMin)
        //        {
        //            Console.WriteLine("On time");
        //        }
        //        else if (Time >= 60)
        //        {
        //            if (Time % 60 < 10)
        //            {
        //                Console.WriteLine("Early");
        //                Console.WriteLine("{0}:0{1} hours before the start", Time / 60, Time % 60);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Early");
        //                Console.WriteLine("{0}:{1} hours before the start", Time / 60, Time % 60);
        //            }

        //        }
        //        else if (Time < 60 && Time <= 30)
        //        {
        //            Console.WriteLine("On time");
        //            Console.WriteLine("{0} minutes before the start", Time);
        //        }
        //        else if (Time < 60 && Time > 30)
        //        {
        //            Console.WriteLine("Early");
        //            Console.WriteLine("{0} minutes before the start", Time);
        //        }
        //    }
        //}


    }
    }
}
