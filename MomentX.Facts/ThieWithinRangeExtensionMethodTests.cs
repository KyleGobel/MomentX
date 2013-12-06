using System;
using Xunit;

namespace MomentX.Facts
{
    public class ThieWithinRangeExtensionMethodTests
    {
        [Fact]
        public void IncludingMinAndMaxOverload()
        {
            var min = TimeSpan.FromMilliseconds(1);
            var max = TimeSpan.FromHours(1);

            Assert.True(min.WithinRange(min, max));
            Assert.True(max.WithinRange(min,max));
            Assert.False(min.Subtract(new TimeSpan(1)).WithinRange(min, max));
            Assert.False(max.Add(TimeSpan.FromMilliseconds(1)).WithinRange(min, max));
        }

        [Fact]
        public void NotIncludingMin()
        {
            var min = TimeSpan.FromMilliseconds(1);
            var max = TimeSpan.FromMilliseconds(5);

            Assert.False(min.WithinRange(min, max, false));
            Assert.True(min.WithinRange(min.SubtractMilliseconds(1), max, false));
        }

        [Fact]
        public void NotIncludingMax()
        {
            var min = TimeSpan.FromMilliseconds(1);
            var max = TimeSpan.FromMilliseconds(5);

            Assert.False(max.WithinRange(min, max, true, false));
            Assert.True(max.WithinRange(min, max.AddMilliseconds(1),true, false));
        }

        [Fact]
        public void NotIncludingMinNorMax()
        {
            var min = TimeSpan.FromMilliseconds(1);
            var max = TimeSpan.FromMilliseconds(5);

            Assert.False(min.WithinRange(min, max, false, false));
            Assert.False(max.WithinRange(min, max, false, false));
            Assert.True(min.WithinRange(min.SubtractMilliseconds(1), max, false, false));
            Assert.True(max.WithinRange(min, max.AddMilliseconds(1), false, false));
        }
    }
}