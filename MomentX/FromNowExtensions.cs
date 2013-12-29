using System;
using System.Globalization;

namespace MomentX
{
    public static class FromNowExtensions
    {
        public static string FromNow(this TimeSpan This, bool includeSuffix = true)
        {
            var suffix = includeSuffix ? " ago" : "";
            
            if (This < TimeSpan.FromSeconds(45))
                return "seconds" + suffix;

            if (This < TimeSpan.FromSeconds(90))
                return "a minute" + suffix;

            if (This < TimeSpan.FromSeconds(120))
                return "2 minutes" + suffix;

            if (This < TimeSpan.FromMinutes(45))
                return string.Format("{0} minutes" + suffix, int.Parse(This.Minutes.ToString(CultureInfo.InvariantCulture)));

            if (This < TimeSpan.FromMinutes(90))
                return "an hour" + suffix;

            if (This < TimeSpan.FromMinutes(120))
                return "2 hours" +suffix;

            if (This < TimeSpan.FromHours(22))
                return string.Format("{0} hours" + suffix, int.Parse(This.Hours.ToString(CultureInfo.InvariantCulture)));

            if (This < TimeSpan.FromHours(36))
                return "a day" + suffix;

            if (This < TimeSpan.FromHours(48))
                return "2 days" + suffix;

            if (This < TimeSpan.FromDays(25))
                return string.Format("{0} days" +suffix, int.Parse(This.Days.ToString(CultureInfo.InvariantCulture)));

            if (This < TimeSpan.FromDays(45))
                return "a month" + suffix;

            if (This < TimeSpan.FromDays(60))
                return "2 months" + suffix;

            if (This < TimeSpan.FromDays(345))
                return string.Format("{0} months" + suffix ,int.Parse((This.Days / 30).ToString(CultureInfo.InvariantCulture)));

            if (This < TimeSpan.FromDays(547))
                return "a year" + suffix;

            return This < TimeSpan.FromDays(712) ? "2 years" + suffix : string.Format("{0} years" +suffix, int.Parse((This.Days/365).ToString(CultureInfo.InvariantCulture)));
        }
    }

    public static class InRangeExtensions
    {
        public static bool WithinRange(this TimeSpan This , TimeSpan min, TimeSpan max, bool includingMinValue = true, bool includingMaxValue = true)
        {
            if (includingMinValue && includingMaxValue)
                return This >= min && This <= max;
            if (!includingMinValue && includingMaxValue)
                return This > min && This <= max;
            if (includingMinValue && !includingMaxValue)
                return This >= min && This < max;
            
            return This > min && This < max;
        }
    }
}
