namespace Core
{
    using System;

    public class Birthday
    {
        private const int PlaceholderLeapYear = 2000;

        public Birthday(int month, int day)
        {
            new DateTime(PlaceholderLeapYear, month, day);
            Day = day;
            Month = month;
        }

        public int Day { get; set; }

        public int Month { get; set; }

        public static bool operator <(Birthday self, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, self.Month, self.Day) < dateTime;
        }

        public static bool operator <=(Birthday self, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, self.Month, self.Day) <= dateTime;
        }

        public static bool operator >(Birthday self, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, self.Month, self.Day) > dateTime;
        }

        public static bool operator >=(Birthday self, DateTime dateTime)
        {
            return new DateTime(dateTime.Year, self.Month, self.Day) >= dateTime;
        }
    }
}