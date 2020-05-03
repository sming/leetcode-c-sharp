using System;
using Xunit;

namespace TheMaze.Test
{
    public class TheMazeTest
    {
        [Fact]
        public void BallArrivesTest()
        {
            int[] arr0 = new int[] { 0, 0, 1, 0, 0 };
            int[] arr1 = new int[] { 0, 0, 0, 0, 0 };
            int[] arr2 = new int[] { 0, 0, 0, 1, 0 };
            int[] arr3 = new int[] { 1, 1, 0, 1, 1 };
            int[] arr4 = new int[] { 0, 0, 0, 0, 0 };

            var maze = new int[][] { arr0, arr1, arr2, arr3, arr4 };

            var tm = new TheMaze();
            int[] start = new int[] { 0, 4 };
            int[] end = new int[] { 3, 2 };
            Console.Out.WriteLine("Path? " + tm.HasPath(maze, start, end));
        }

        [Fact]
        public void BallIsBlockedTest()
        {
            int[] arr0 = new int[] { 0, 0, 1, 0, 0 };
            int[] arr1 = new int[] { 0, 0, 0, 0, 0 };
            int[] arr2 = new int[] { 0, 0, 0, 1, 0 };
            int[] arr3 = new int[] { 1, 1, 1, 1, 1 };
            int[] arr4 = new int[] { 0, 0, 0, 0, 0 };

            var maze = new int[][] { arr0, arr1, arr2, arr3, arr4 };

            var tm = new TheMaze();
            int[] start = new int[] { 0, 4 };
            int[] end = new int[] { 3, 2 };
            Console.Out.WriteLine("Path? " + tm.HasPath(maze, start, end));
        }

        [Fact]
        public void BallFailsToStopTest()
        {

        }
    }
}
