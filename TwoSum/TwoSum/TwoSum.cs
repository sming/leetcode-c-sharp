using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoSum
{
    /*
     * @lc app=leetcode id=1 lang=csharp
     *
     * [1] Two Sum
     *
     * https://leetcode.com/problems/two-sum/description/
     *
     * algorithms
     * Easy (45.26%)
     * Total Accepted:    2.8M
     * Total Submissions: 6.2M
     * Testcase Example:  '[2,7,11,15]\n9'
     *
     * Given an array of integers, return indices of the two numbers such that they
     * add up to a specific target.
     *
     * You may assume that each input would have exactly one solution, and you may
     * not use the same element twice.
     *
     * Example:
     *
     *
     * Given nums = [2, 7, 11, 15], target = 9,
     *
     * Because nums[0] + nums[1] = 2 + 7 = 9,
     * return [0, 1].
     *
     *
     */

    public class Solution
    {
        /**
         * Given an array of integers, return indices of the two numbers such
         * that they add up to a specific target.
        */
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return null;

            var sortedNums = new int[nums.Length];
            Array.Copy(nums, sortedNums, nums.Length);
            Array.Sort(sortedNums);

            for (int i = 0; i < sortedNums.Length; i++)
            {
                int goal = target - sortedNums[i];
                int idxComplement = FindComplementOf(sortedNums, 0, sortedNums.Length - 1, goal, i);

                if (idxComplement != -1)
                {
                    // now we have to find the indexes in the original array :/
                    int number1 = sortedNums[i];
                    int number2 = sortedNums[idxComplement];

                    var numList = new List<int>(nums);
                    int idxNumber1 = numList.IndexOf(number1);
                    int idxNumber2 = numList.IndexOf(number2);

                    if (idxNumber1 == idxNumber2)
                        idxNumber2 = numList.IndexOf(number2, idxNumber1 + 1);

                    if (idxNumber1 < idxNumber2)
                        return new int[] { idxNumber1, idxNumber2 };
                    else
                        return new int[] { idxNumber2, idxNumber1 };

                }
            }

            return null;
        }

        private int FindComplementOf(int[] nums, int lowIdx, int highIdx, int goal, int idxThatMustNotBeUsed)
        {
            int IsTargetFound(int idxToCheck)
            {
                if (nums[idxToCheck] == goal && idxToCheck != idxThatMustNotBeUsed)
                    return idxToCheck;

                return -1;
            }

            if (lowIdx > highIdx)
                return -1;

            if (highIdx - lowIdx < 3)
            {
                if (IsTargetFound(lowIdx) != -1)
                    return lowIdx;
                if (IsTargetFound(highIdx) != -1)
                    return highIdx;
            }

            int pivotIdx = (lowIdx + highIdx) / 2;
            // If the pivot's too big, focus on the lower half of the array. Else focuse
            // on the upper half.
            if (nums[pivotIdx] > goal)
                highIdx = pivotIdx - 1;
            else
                lowIdx = pivotIdx + 1;

            return FindComplementOf(nums, lowIdx, highIdx, goal, idxThatMustNotBeUsed);
        }
    }
}
