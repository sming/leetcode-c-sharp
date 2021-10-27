using System;
using System.Collections.Generic;

namespace ClimbingStairs
{
    /*
     * @lc app=leetcode id=70 lang=csharp
     *
     * [70] Climbing Stairs
     *
     * https://leetcode.com/problems/climbing-stairs/description/
     *
     * algorithms
     * Easy (46.53%)
     * Total Accepted:    629.4K
     * Total Submissions: 1.4M
     * Testcase Example:  '2'
     *
     * You are climbing a stair case. It takes n steps to reach to the top.
     *
     * Each time you can either climb 1 or 2 steps. In how many distinct ways can
     * you climb to the top?
     *
     * Note: Given n will be a positive integer.
     *
     * Example 1:
     *
     *
     * Input: 2
     * Output: 2
     * Explanation: There are two ways to climb to the top.
     * 1. 1 step + 1 step
     * 2. 2 steps
     *
     *
     * Example 2:
     *
     *
     * Input: 3
     * Output: 3
     * Explanation: There are three ways to climb to the top.
     * 1. 1 step + 1 step + 1 step
     * 2. 1 step + 2 steps
     * 3. 2 steps + 1 step
     *
     * PSK so, we're going to want to store the different ways you
     * can reach step x because there're gonna be a million different
     * ways to reach it
     * stairNum => Set { List1, List2... ListP }
     *
     * Could do a DFS where there are 2 adjacent nodes
     */
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            var stairCache = new Dictionary<int, HashSet<Stack<int>>>();
            var stackOfSteps = new Stack<int>();
            RecursivelyClimbStairs(0, n, stackOfSteps, stairCache);

            return stairCache.GetValueOrDefault(n).Count;
        }

        private void RecursivelyClimbStairs(int stairIdx, int numStairs, Stack<int> stackOfSteps, Dictionary<int, HashSet<Stack<int>>> stairCache)
        {
            if (stairIdx > numStairs)
                return; // we've stepped over the n stair i.e. don't store this solution
            else if (stairIdx == numStairs)
                stairCache[stairIdx].Add(stackOfSteps);

        }
    }
}
