using System;
using System.Collections.Generic;
using System.Linq;

/**
 * Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s. A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.

Example 1:
Given tree s:

     3
    / \
   4   5
  / \
 1   2
Given tree t:
   4 
  / \
 1   2
Return true, because t has the same structure and node values with a subtree of s.
Example 2:
Given tree s:

     3
    / \
   4   5
  / \
 1   2
    /
   0
Given tree t:
   4
  / \
 1   2
Return false.
    */
namespace SubTree
{
    //class Node<T>
    //{
    //    private T value;
    //    public Node(T val, Node<T> next = null)
    //    {
    //        value = val;
    //        this.next = next;
    //    }

    //    private Node<T> next;

    //    public T Value { get => value; set => this.value = value; }
    //    internal Node<T> Next { get => next; set => next = value; }
    //}

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class SubTreeDetector
    {
        // Is t a subtree of s?
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
                throw new ArgumentNullException("Both s and t must be non-null.");

            var sList = new List<int>();
            LayoutTreeAsList(s, sList);

            var tList = new List<int>();
            LayoutTreeAsList(t, tList);

            int[] startingIndices = FindAllIndexof(sList, t.val);
            foreach (int sIdx in startingIndices)
            {
                if (sList.Count > sIdx + tList.Count)
                {
                    var sListSlice = sList.GetRange(sIdx, tList.Count);
                    if (sListSlice == tList)
                        return true;
                }
            }

            return false;
        }

        public static int[] FindAllIndexof(IEnumerable<int> values, int val)
        {
            return values.Select((b, i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
        }

        private void LayoutTreeAsList(TreeNode n, List<int> treeAsList)
        {
            treeAsList.Add(n.val);
            if (n.left != null)
                LayoutTreeAsList(n.left, treeAsList);
            if (n.right != null)
                LayoutTreeAsList(n.right, treeAsList);
        }
    }
}
