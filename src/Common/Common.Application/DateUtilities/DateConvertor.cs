using System.Globalization;

namespace Common.Application.DateUtilities
{
    public static class DateConvertor
    {
        public static DateTime ToMiladi(this string persianDate)
        {
            try
            {
                string[] Date = persianDate.Split("/");

                return new DateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), new PersianCalendar());
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return
                persianCalendar.GetYear(dateTime)
                + "/" +
                persianCalendar.GetMonth(dateTime).ToString("00")
                + "/" +
                persianCalendar.GetDayOfMonth(dateTime).ToString("00");
        }

        public static string ToShamsi(this DateTime? dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return persianCalendar.GetYear((DateTime)dateTime) + "/" +
                persianCalendar.GetMonth((DateTime)dateTime).ToString("00") + "/" +
                persianCalendar.GetDayOfMonth((DateTime)dateTime).ToString("00");
        }

        private static string GetDayOfWeekString(int day)
        {
            string[] days = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };

            if (day <= days.Length)
            {
                return days[day];
            }
            return "";
        }

        private static string GetMonthString(int month)
        {
            string[] months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            if (month <= months.Length)
            {
                return months[month - 1];
            }
            return "";
        }

    }
}

