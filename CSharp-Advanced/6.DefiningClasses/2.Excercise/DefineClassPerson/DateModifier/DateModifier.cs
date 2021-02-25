using System;
using System.Collections.Generic;
using System.Linq;

public class DateModifier
{
    public long CalculateDate(List<DateTime> listOfDates)
    {
        TimeSpan result = listOfDates[0] - listOfDates[1];
        string currTime = result.ToString();

        long finalResult = CalculateExactTime(currTime);
        return finalResult;
    }

    private long CalculateExactTime(string currTime)
    {
        string[] result = currTime.Split('.').ToArray();
        long finalResult = Math.Abs(long.Parse(result[0]));
        return finalResult;
    }
}