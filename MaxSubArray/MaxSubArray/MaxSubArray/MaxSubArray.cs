using System;

//Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.

//Example:

//Input: [-2,1,-3,4,-1,2,1,-5,4],
//Output: 6
//Explanation: [4,-1,2,1] has the largest sum = 6.
//Follow up:


//If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
//Examples
// 1 -10  4  -1  2  -10 = 5
// 5 6 -20 2 = 11
// 3 -1 1 = 3
// 3 -2 1 = 2
// 3 -3 1 = 1 (either way)
// 3 -4 1 = 1 (last way)
// 3 -5 1 = 1 (last way)
// 3 -50 60 = 60

// so, for startIdx if next number takes you to < 1, skip it. Now for endIdx
//
// 3 -1 5 = 7
// 3 -1 2 = 4
// 3 -1 0 = 2
// 3 -1 -1 = 3
// but 3 -1 -1 10 = 11 so it's "worth" skipping the two -1's to get to 10
// plus, startidx and endidx have to work in tandem. Could you do sum to that
// point?
// 3 -1 -1 10 => 3 2 2 11 - but that's based on same startIdx and it can move
// Problem is that you can't just use local maxima to obtain global maxima.
namespace MaxSubArray
{
    public class MaxSubArray
    {
        public int MaxSubArray(int[] nums)
        {
            int startIdx = 0, endIdx = 1, currentSum = nums[0];
            int max = int.MinValue;
            while (endIdx < nums.Length)
            {
                if (startIdx == endIdx)
                {
                    endIdx++;
                    continue;
                }

                int biggestStep = 0;
                int nextEndIdx = endIdx == nums.Length - 1 ? endIdx : endIdx;


                //biggestStep = Math.Max(nums[startIdx + 1], nums[nextEndIdx]);
                if (nums[startIdx + 1] > nums[nextEndIdx])
                {
                    startIdx
                }
                if (nums[startIdx + 1] > nums[staIdx])
                {
                    startIdx
                }
                if (nums[startIdx + 1] > nums[nextEndIdx])
                {
                    startIdx
                }

            }
        }
    }
}
