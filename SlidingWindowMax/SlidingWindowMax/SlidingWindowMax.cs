/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 *
 * https://leetcode.com/problems/sliding-window-maximum/description/
 *
 * algorithms
 * Hard (41.68%)
 * Total Accepted:    250.6K
 * Total Submissions: 595.7K
 * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
 *
 * Given an array nums, there is a sliding window of size k which is moving
 * from the very left of the array to the very right. You can only see the k
 * numbers in the window. Each time the sliding window moves right by one
 * position. Return the max sliding window.
 *
 * Follow up:
 * Could you solve it in linear time?
 *
 * Example:
 *
 *
 * Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
 * Output: [3,3,5,5,6,7]
 * Explanation:
 *
 *   Window position                Max
 *   ---------------               -----
 * 1.  [1  3  -1] -3  5  3  6  7       3
 * 2.   1 [3  -1  -3] 5  3  6  7       3
 * 3.   1  3 [-1  -3  5] 3  6  7       5
 * 4.   1  3  -1 [-3  5  3] 6  7       5
 * 5.   1  3  -1  -3 [5  3  6] 7       6
 * 6.   1  3  -1  -3  5 [3  6  7]      7
 *
 * Input: nums = [1,3,-1,-3,5,3,6,7], and k = ***4***
 * Output: [3,3,5,5,6,7]
 * Explanation:
 *
 * Window position                Max
 * ---------------               -----
 * [1  3  -1 -3]  5  3  6  7       3
 * ⁠1 [3  -1  -3  5]  3  6  7       5
 * ⁠1  3 [-1  -3  5  3]  6  7       5
 * ⁠1  3  -1 [-3  5  3  6]  7       6
 * ⁠1  3  -1  -3 [5  3  6  7]      76
 *
 *
 * Constraints:
 *
 *
 * 1 <= nums.length <= 10^5
 * -10^4 <= nums[i] <= 10^4
 * 1 <= k <= nums.length
 *
 * PSK NOTES ————————————
 * - input is int nums[] and int k
 * - sliding window of size k which is moving from the very left of the array to the very right
 * - can only see the k numbers in the window.
 * - Each time the sliding window moves right by one position.
 * - Return the max sliding window.
 *
 * Simple Solution
 * for i in 0 to numidx - k of nums
 *   sum = nums.Sum(i => i...i+k)
 *   if sum > maxSum
 *     maxSum = sum
 *
 */
using System;
using System.Linq;
namespace SlidingWindowMax
{
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int numWindows = nums.Length - k + 1;
            int[] maxOfWindows = new int[numWindows];
            for (int i = 0; i < numWindows; i++)
            {
                int sum = nums.Skip(i).Take(k).Max();
                maxOfWindows[i] = sum;
            }

            return maxOfWindows;
        }

        /*
        L = length of nums
        Big O: O(LK). This can vary a lot, depending on L and K. If K is
        1, it's linear. But if L is 100,000 and K is 10,000, 900,000,000
        operations will be done. Which is a lot. Can we guarantee linear?
        Use a hashmap or some other auxilliary DS?
         */
        public int[] MaxSlidingWindowNonLinear(int[] nums, int k)
        {
            int numWindows = nums.Length - k + 1;
            int[] maxOfWindows = new int[numWindows];
            for (int i = 0; i < numWindows; i++)
            {
                int sum = nums.Skip(i).Take(k).Max();
                maxOfWindows[i] = sum;
            }

            return maxOfWindows;
        }
    }
}