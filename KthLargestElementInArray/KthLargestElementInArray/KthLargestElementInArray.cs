using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * From ./csharp/StacksNQueues/StacksNQueues/Node.cs :
 */
public class Node<T>
{
    public T _val;
    public Node<T> _next;
    public Node(T val, Node<T> next = null)
    {
        this._val = val;
        this._next = next;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(this._val);
        var node = this;
        while (node._next != null)
        {
            node = node._next;
            sb.Append(node._val);
        }

        return sb.ToString();
    }
}

/*
 * @lc app=leetcode id=215 lang=csharp
 *
 * [215] Kth Largest Element in an Array
 *
 * https://leetcode.com/problems/kth-largest-element-in-an-array/description/
 *
 * algorithms
 * Medium (53.35%)
 * Total Accepted:    592.8K
 * Total Submissions: 1.1M
 * Testcase Example:  '[3,2,1,5,6,4]\n2'
 *
 * Find the kth largest element in an unsorted array. Note that it is the kth
 * largest element in the sorted order, not the kth distinct element.
 * 
 * Example 1:
 * 
 * 
 * Input: [3,2,1,5,6,4] and k = 2
 * Output: 5
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [3,2,3,1,2,4,5,5,6] and k = 4
 * Output: 4
 * 
 * Note: 
 * You may assume k is always valid, 1 ≤ k ≤ array's length.
 * 
 */

public class Solution
{
    public int FindKthLargestNaive(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            throw new ArgumentException("The 'nums' parameter must contain at least one element.");

        int idxKth = nums.Length - k;
        //return nums.OrderBy(x => x).ToArray()[idxKth];
        Array.Sort(nums);
        return nums[idxKth];
    }

    public int FindKthLargestViaHeap(int[] nums, int k)
    {
        return 0;
    }

    public Node<int> Heapify(int[] nums)
    {

    }
}
