using System;
using NUnit.Framework;
namespace SlidingWindowMax.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var s = new Solution();

            var expected = new int[] { 3, 3, 5, 5, 6, 7 };
            var input = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            Assert.AreEqual(expected, s.MaxSlidingWindow(input, k));
        }

        [Test]
        public void Test0()
        {
            var s = new Solution();

            var expected = new int[] { 3 };
            var input = new int[] { 3 };
            int k = 1;
            Assert.AreEqual(expected, s.MaxSlidingWindow(input, k));
        }

        [Test]
        public void Test2()
        {
            var s = new Solution();

            var expected = new int[] { 3, 5, 5, 6, 7 };
            var input = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 4;
            Assert.AreEqual(expected, s.MaxSlidingWindow(input, k));
        }
    }
}