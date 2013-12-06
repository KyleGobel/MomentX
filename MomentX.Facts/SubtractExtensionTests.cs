using System;
using Xunit;

namespace MomentX.Facts
{
    public class SubtractExtensionTests
    {
        [Fact]
        public void SubtractMilliseconds()
        {
            Assert.Equal(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(2).SubtractMilliseconds(1));
        }

        [Fact]
        public void SubtractSeconds()
        {
            Assert.Equal(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3).SubtractSeconds(1));
        }

        [Fact]
        public void SubtractMinutes()
        {
            Assert.Equal(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(3).SubtractMinutes(1));
        }

        [Fact]
        public void SubtractHours()
        {
            Assert.Equal(TimeSpan.Zero, TimeSpan.FromHours(0.5).SubtractHours(0.5));
        }

        [Fact]
        public void SubtractDays()
        {
            Assert.Equal(TimeSpan.FromDays(0.7), TimeSpan.FromDays(1).SubtractDays(0.3));
        }

        [Fact]
        public void SubtractWeeks()
        {
            Assert.Equal(TimeSpan.Zero, TimeSpan.FromDays(21).SubtractWeeks(3));
        }
    }
}