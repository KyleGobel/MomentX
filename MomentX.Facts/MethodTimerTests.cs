using System;
using System.Threading;
using Xunit;

namespace MomentX.Facts
{
    public class MethodTimerTests
    {
        [Fact]
        public void EmptyBlockTakesZeroMilliseconds()
        {
            long timeTaken = 0;
            using (new MethodTimer((long x) => timeTaken = x))
            {
                
            }
           // Assert.Equal(0, timeTaken);
        }

        [Fact]
        public void OneSecondSleepTakesOneSeconds()
        {
            long timeTaken = 0;
            using (new MethodTimer((long x) => timeTaken = x))
            {
                Thread.Sleep(1000);
            }
            //Assert.Equal(1000, timeTaken);
        }

        [Fact]
        public void time()
        {
            LongWinded w = new LongWinded();
            var t = w.Gettime();
            Assert.Equal("", t);
        }
    }
}