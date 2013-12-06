using System;
using Xunit;

namespace MomentX.Facts
{
    public class AddExtensionsTests
    {
        [Fact]
        public void AddMilliseconds()
        {
            Assert.Equal(TimeSpan.FromMilliseconds(1), TimeSpan.Zero.AddMilliseconds(1));
        }

        [Fact]
        public void AddSeconds()
        {
            Assert.Equal(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1).AddSeconds(1));
        }

        [Fact]
        public void AddMinutes()
        {
            Assert.Equal(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(1).AddMinutes(1));
        }

        [Fact]
        public void AddHours()
        {
            Assert.Equal(TimeSpan.FromHours(1), TimeSpan.FromHours(0.5).AddHours(0.5));
        }

        [Fact]
        public void AddDays()
        {
            Assert.Equal(TimeSpan.FromDays(1), TimeSpan.FromDays(0.7).AddDays(0.3));
        }

        [Fact]
        public void AddWeeks()
        {
            Assert.Equal(TimeSpan.FromDays(21), TimeSpan.Zero.AddWeeks(3));
        }
    }
}