using System;

namespace MomentX
{
    public static class PrettyTimeExtension
    {
        public static string PrettyTime(this TimeSpan This)
        {
            if (This < TimeSpan.FromSeconds(10))
                return Math.Round(This.TotalMilliseconds) + "ms";
            if (This < TimeSpan.FromMinutes(1))
                return "about " + Math.Round(This.TotalSeconds) + " seconds";
            if (This < TimeSpan.FromHours(1))
                return "about " + Math.Round(This.TotalMinutes) + "m " + This.Seconds + " s";

            return This.Days + "d:" + This.Hours + "h:" + This.Minutes + "m:" + This.Seconds + "s";

        }
    }
}