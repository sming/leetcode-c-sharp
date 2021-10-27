using System;
using Xunit;

namespace PerfectSquares.Test
{
    public class PerfectSquaresTest
    {
        [Fact]
        public void TestTwelve()
        {
            var s = new Solution();
            Assert.Equal(3, s.NumSquares(12));
        }
    }
}
