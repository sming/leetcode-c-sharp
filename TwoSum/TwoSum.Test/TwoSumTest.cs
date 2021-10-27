using System;
using Xunit;

namespace TwoSum.Test
{
    public class TwoSumTest
    {
        /**
         * 
         *
         * Given nums = [2, 7, 11, 15], target = 9,
         *
         * Because nums[0] + nums[1] = 2 + 7 = 9,
         * return [0, 1].
         */
        [Fact]
        public void Example1Test()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var s = new Solution();
            var res = s.TwoSum(nums, 9);

            Assert.Equal(new int[] { 0, 1 }, res);
        }

        [Fact]
        public void Example2Test()
        {
            var nums = new int[] { 3, 2, 4 };
            var s = new Solution();
            var res = s.TwoSum(nums, 6);

            Assert.Equal(new int[] { 1, 2 }, res);
        }

        [Fact]
        public void Example3Test()
        {
            var nums = new int[] { 3, 3 };
            var s = new Solution();
            var res = s.TwoSum(nums, 6);

            Assert.Equal(new int[] { 0, 1 }, res);
        }

        [Fact]
        public void Example4Test()
        {
            var nums = new int[] { 0, 4, 3, 0 };
            var s = new Solution();
            var res = s.TwoSum(nums, 0);

            Assert.Equal(new int[] { 0, 3 }, res);
        }
    }
}
