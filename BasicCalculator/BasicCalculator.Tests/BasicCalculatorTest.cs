using NUnit.Framework;

namespace BasicCalculator.Tests
{
    public class BasicCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var s = new Solution();
            Assert.AreEqual(-2, s.Calculate("1 + 2 - 5"));
            Assert.AreEqual(-8, s.Calculate("0-1 - 2 - 5"));
            Assert.AreEqual(11, s.Calculate("0-11 + 22 + 0"));
        }
    }
}