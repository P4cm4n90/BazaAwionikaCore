using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web
{
    public static class CalcHelper
    {
        public static int CalcDaysBetweenDates(DateTime start, DateTime end)
        {
            TimeSpan time = start - end;
            return (int)time.TotalDays;
        }
    }
}