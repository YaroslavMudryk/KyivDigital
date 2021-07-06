using System;

namespace KyivDigital.Business.Helpers
{
    public class DateTimeHelper
    {
        public static string GetTitleTime(DateTime dateTime)
        {
            var diff = DateTime.Today.Subtract(dateTime);
            if (diff == TimeSpan.FromDays(0))
                return "Сьогодні";
            if (diff == TimeSpan.FromDays(1))
                return "Вчора";
            return dateTime.ToString("dd MMMM yyyy");
        }
    }
}