using System;
using System.Globalization;

namespace KyivDigital.Business.Helpers
{
    public class DateTimeHelper
    {
        public static string GetTitleTime(DateTime dateTime)
        {
            var today = DateTime.Today;
            var diff = today.Subtract(dateTime);
            if (diff.Days == 0)
            {
                if (today.Day == dateTime.Day)
                    return "Сьогодні";
                return "Вчора";
            }
            if (diff.Days == 1)
                return "Вчора";
            if (diff.Days <= 365)
                return dateTime.ToString("dd MMMM", CultureInfo.CreateSpecificCulture("uk"));
            return dateTime.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("uk"));
        }
    }
}