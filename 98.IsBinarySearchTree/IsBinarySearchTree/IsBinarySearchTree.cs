/*
 * @lc app=leetcode id=98 lang=csharp
 *
 * [98] Validate Binary Search Tree
 *
 * https://leetcode.com/problems/validate-binary-search-tree/description/
 *
 * algorithms
 * Medium (27.33%)
 * Total Accepted:    636.5K
 * Total Submissions: 2.3M
 * Testcase Example:  '[2,1,3]'
 *
 * Given a binary tree, determine if it is a valid binary search tree (BST).
 * 
 * Assume a BST is defined as follows:
 * 
 * 
 * The left subtree of a node contains only nodes with keys less than the node's key.
 * The right subtree of a node contains only nodes with keys greater than the node's key.
 * Both the left and right subtrees must also be binary search trees.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * ⁠   2
 * ⁠  / \
 * ⁠ 1   3
 * 
 * Input: [2,1,3]
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * ⁠   5
 * ⁠  / \
 * ⁠ 1   4
 * / \
 * 3   6
 * 
 * Input: [5,1,4,null,null,3,6]
 * Output: false
 * Explanation: The root node's value is 5 but its right child's value is 4.
 * 
 * 
 */

using System;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

/*
 * [10,5,15,null,null,6,20]
 * [10,5,15,null,null,12,20]
 *          10
 *      5       15              BAD
 *    3   16   12  13
 *                17 21
 *           
 *  so, as we progress, we build a list of requirements. 6 would have:
 *  > 10
 *  < 15
 *  would everything below 6 have that?
 *  20 would have:
 *  > 10
 *  > 15
 *  > 20
 *  17 would have:
 *  > 10
 *  > 15
 *  < 20
 *  so we can store a max and min, not a lhs and rhs
 *
 *          10
 *      5       15              BAD
 *        3     6  20
 *
 *  [2147483647]
 *                  2
 *            1             4
 *      
 */
public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        return IsValidBSTRecursive(root, int.MaxValue, int.MinValue);
    }

    private bool IsValidBSTRecursive(TreeNode node, int lower, int upper)
    {
        if (node == null)
            return true;

        int val = node.val;

        if (val <= lower || val >= upper)
            return false;

        if (!IsValidBSTRecursive(node.right, val, upper))
            return false;
        if (!IsValidBSTRecursive(node.left, lower, val))
            return false;

        return true;
    }


}
