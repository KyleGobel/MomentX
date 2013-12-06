using System;

namespace MomentX
{
    public static class AddSubtractExtensions
    {
        public static TimeSpan AddMilliseconds(this TimeSpan This, double milliseconds)
        {
            return This.Add(TimeSpan.FromMilliseconds(milliseconds));
        }

        public static TimeSpan AddSeconds(this TimeSpan This, double seconds)
        {
            return This += TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan AddMinutes(this TimeSpan This, double minutes)
        {
            return This += TimeSpan.FromMinutes(minutes);
        }
        public static TimeSpan AddHours(this TimeSpan This, double hours)
        {
            return This += TimeSpan.FromHours(hours);
        }

        public static TimeSpan AddDays(this TimeSpan This, double days)
        {
            return This += TimeSpan.FromDays(days);
        }

        public static TimeSpan AddWeeks(this TimeSpan This, double weeks)
        {
            return This += TimeSpan.FromDays(7 * weeks);
        }
    }

    public static class SubtractExtenstions
    {
        public static TimeSpan SubtractMilliseconds(this TimeSpan This, double milliseconds)
        {
            return This.Subtract(TimeSpan.FromMilliseconds(milliseconds));
        }

        public static TimeSpan SubtractSeconds(this TimeSpan This, double seconds)
        {
            return This -= TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan SubtractMinutes(this TimeSpan This, double minutes)
        {
            return This -= TimeSpan.FromMinutes(minutes);
        }
        public static TimeSpan SubtractHours(this TimeSpan This, double hours)
        {
            return This -= TimeSpan.FromHours(hours);
        }

        public static TimeSpan SubtractDays(this TimeSpan This, double days)
        {
            return This -= TimeSpan.FromDays(days);
        }

        public static TimeSpan SubtractWeeks(this TimeSpan This, double weeks)
        {
            return This -= TimeSpan.FromDays(7 * weeks);
        }
    }
}