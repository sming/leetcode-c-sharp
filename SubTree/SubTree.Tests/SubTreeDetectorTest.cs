using System;
using Xunit;
using SubTree;

namespace SubTree.Tests
{
    public class SubTreeDetectorTests
    {
        [Fact]
        public void Test1()
        {
            var s = new SubTreeDetector();

            var t = new TreeNode(5);
            t.left = new TreeNode(4);
            t.right = new TreeNode(6);
        }
    }
}
