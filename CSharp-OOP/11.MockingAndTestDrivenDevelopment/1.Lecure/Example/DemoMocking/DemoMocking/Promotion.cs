using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMocking
{
    public class Promotion
    {
        private DateTime dateToday;

        public Promotion(DateTime today)
        {
            this.dateToday = today;
        }

        public Promotion()
            :this(DateTime.Now)
        {

        }

        public int CalculateDiscount(int price)
        {
            return price - price * GetDiscount() / 100;
        }

        public int GetDiscount()
        {

            if (dateToday.DayOfWeek == DayOfWeek.Monday)
            {
                return 30;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Tuesday)
            {
                return 10;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 40;
            }
            if (dateToday.DayOfWeek == DayOfWeek.Sunday)
            {
                return -10;
            }

            return 0;
        }

    }
}
