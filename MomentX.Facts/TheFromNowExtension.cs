using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace MomentX.Facts
{
    public class TheFromNowExtension
    {
        [Fact]
        public void ShouldBeInSecondsAgoRangeFromZeroToFortyFiveSeconds()
        {
            const string expectedOutput = "seconds ago";
            var maxValue = TimeSpan.FromSeconds(45).Subtract(TimeSpan.FromMilliseconds(1));
            var minValue = TimeSpan.FromSeconds(0);

            Assert.Equal(expectedOutput, maxValue.FromNow());
            Assert.Equal(expectedOutput, minValue.FromNow());
        }

        [Fact]
        public void ShouldBeInAMinuteAgoRangeFrom45SecondsTo90()
        {
            const string expectedOutput = "a minute ago";
            var minValue = TimeSpan.FromSeconds(45);
            var maxValue = TimeSpan.FromSeconds(90).Subtract(TimeSpan.FromMilliseconds(1));

            Assert.Equal(expectedOutput, maxValue.FromNow());
            Assert.Equal(expectedOutput, minValue.FromNow());
        }

        [Fact]
        public void ShouldBeInXMinutesAgoRangeFrom90SecondsTo45Minutes()
        {
            var minValue = TimeSpan.FromSeconds(90);
            var maxValue = TimeSpan.FromMinutes(45).Subtract(TimeSpan.FromMilliseconds(1));

            Assert.Equal("2 minutes ago", minValue.FromNow());
            Assert.Equal("44 minutes ago", maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInAnHourAgoRangeFrom45MinutesTo90Minutes()
        {
            const string expectedOutput = "an hour ago";
            var minValue = TimeSpan.FromMinutes(45);
            var maxValue = TimeSpan.FromMinutes(90).SubtractMilliseconds(1);

            Assert.Equal(expectedOutput, minValue.FromNow());
            Assert.Equal(expectedOutput, maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInXHoursAgoRangeFrom2HoursTo22Hours()
        {
            var minValue = TimeSpan.FromHours(2);
            var maxValue = TimeSpan.FromHours(22).SubtractMilliseconds(1);

            Assert.Equal("2 hours ago", minValue.FromNow());
            Assert.Equal("21 hours ago", maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInADayAgoRangeFrom22HoursTo36Hours()
        {
            const string expectedOutput = "a day ago";
            var minValue = TimeSpan.FromHours(22);
            var maxValue = TimeSpan.FromHours(36).SubtractMilliseconds(1);

            Assert.Equal(expectedOutput, minValue.FromNow());
            Assert.Equal(expectedOutput, maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInXDaysAgoFrom36HoursTo25Days()
        {
            var minValue = TimeSpan.FromHours(36);
            var maxValue = TimeSpan.FromDays(25).SubtractMilliseconds(1);

            Assert.Equal("2 days ago", minValue.FromNow());
            Assert.Equal("24 days ago", maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInAMonthAgoRangeFrom25DaysTo45Days()
        {
            const string expectedOutput = "a month ago";
            var minValue = TimeSpan.FromDays(25);
            var maxValue = TimeSpan.FromDays(45).SubtractMilliseconds(1);

            Assert.Equal(expectedOutput, minValue.FromNow());
            Assert.Equal(expectedOutput, maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInXMonthsAgoRangeFrom45DaysTo345Days()
        {
            var minValue = TimeSpan.FromDays(45);
            var maxValue = TimeSpan.FromDays(345).SubtractMilliseconds(1);

            Assert.Equal("2 months ago", minValue.FromNow());
            Assert.Equal("11 months ago", maxValue.FromNow());
        }

        [Fact]
        public void ShouldBeInAYearAgoRangeFrom345DaysTo547Days()
        {
            const string expectedOutput = "a year ago";
            var minValue = TimeSpan.FromDays(345);
            var maxValue = TimeSpan.FromDays(547).SubtractMilliseconds(1);

            Assert.Equal(expectedOutput, minValue.FromNow());
            Assert.Equal(expectedOutput, maxValue.FromNow());
        }

        [Fact]
        public void ShouldbeInXYearsAgoRangeAbove547Days()
        {
            var minValue = TimeSpan.FromDays(547);
            var maxValue = TimeSpan.FromDays(365*10000);

            Assert.Equal("2 years ago", minValue.FromNow());
            Assert.Equal("10000 years ago", maxValue.FromNow());
        }
    }
}
