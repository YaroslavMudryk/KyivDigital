using System;
using System.Globalization;

namespace KyivDigital.Business.Helpers
{
    public class DateTimeHelper
    {
        public static string GetTitleTime(DateTime dateTime)
        {
            var today = DateTime.Now;
            var diff = today.Subtract(dateTime);
            var time = dateTime.ToString("HH:mm");
            if (diff.Days == 0)
            {
                if (today.Day == dateTime.Day)
                    return $"Сьогодні ({time})";
                return $"Вчора ({time})";
            }
            if (diff.Days == 1)
                return $"Вчора ({time})";
            if (dateTime.Year == today.Year)
                return dateTime.ToString($"dd MMMM ({time})", CultureInfo.CreateSpecificCulture("uk"));
            return dateTime.ToString($"dd MMMM yyyy ({time})", CultureInfo.CreateSpecificCulture("uk"));
        }
    }
}