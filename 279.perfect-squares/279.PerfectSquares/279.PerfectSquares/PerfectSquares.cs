
/*
 * @lc app=leetcode id=279 lang=csharp
 *
 * [279] Perfect Squares
 *
 * https://leetcode.com/problems/perfect-squares/description/
 *
 * algorithms
 * Medium (45.16%)
 * Total Accepted:    263.1K
 * Total Submissions: 581.5K
 * Testcase Example:  '12'
 *
 * Given a positive integer n, find the least number of perfect square numbers
 * (for example, 1, 4, 9, 16, ...) which sum to n.
 * 
 * Example 1:
 * 
 * 
 * Input: n = 12
 * Output: 3 
 * Explanation: 12 = 4 + 4 + 4.
 * 
 * Example 2:
 * 
 * 
 * Input: n = 13
 * Output: 2
 * Explanation: 13 = 4 + 9.
 *
 * PSK NOTES ————————————
 *
 * 1 -> 1 == 1
 * 2 -> 2 == 1
 * 3 -> 2, 1 == 2
 * 4 -> 4 == 1
 * 5 -> 4, 1 == 2
 * 6 -> 4, 2 == 2
 * 7 -> 4, 2, 1 == 3
 * 8 -> 4, 4 == 2
 * ...
 * 12 -> 9, 2, 1 OR 4, 4, 4 == 3
 * So, is it true that it's the greediest approach? Need to think of example where
 * we'd need a load of 1's. From some website:
 * Number	Square	
 * 1	    1	    =1 X 1
 * 2	    4	    =2 X 2
 * 3	    9	    =3 X 3
 * 4	    16	    =4 X 4
 * 5	    25	    =5 X 5
 * 6	    36	    =6 X 6
 * 7	    49	    =7 X 7
 * 8	    64	    =8 X 8
 * 9	    81	    =9 X 9
 * 10	    100	    =10 X 10
 * 11	    121	    =11 X 11
 * 12	    144	    =12 X 12
 * 13	    169	    =13 X 13
 * 14	    196	    =14 X 14
 * 15	    225	    =15 X 15
 * 
 * 15 = 9, 4, 2
 * 
 * PSK NOTES END ————————————
 */
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    // So we're gonna have to keep a running tab of how many squares we're currently
    // using. But even if we find 0 remainder, we still need to try other combinations.
    public int NumSquares(int n)
    {
        if (n < 1)
            return 0;

        // OK, so how to find the biggest square beneath n. I think we'd have to build up to one that's
        // bigger than n, which should be bloody fast.
        var listSquares = new List<int>();
        for (int i = 1; i * i < n; i++)
            listSquares.Add(i * i);

        int remainder = n;
        var squareCounts = new SortedDictionary<int, int>();
        //var zeroRemainderSquareCounts = new SortedDictionary<int, int>();
        var squareCountSums = new SortedSet<int>();

        listSquares.Reverse();

        // need to recursively go through all the combinations of squares.
        // need to keep track of the 'current' squareCounts on the current path.
        // this seems to be a stack - when we backtrack we just pop off the stack?
        // but when do we pop off? and what?
        /**
         * build listOfSquares
         * 
         * private ? NumSquaresRecursive(remainder (initially n), listOfSquares, squareIdx, squareStack)
         *  get the max number of this square that fit in remainder
         *  for i = 0 to max number (inclusive)
         *    remainder -= i * square
         *    if i > 0
         *      squareStack.Add(square, i)
         *    
         *    if remainder == 0
         *      // we've found A solution
         *      squareCountSums.Add(squareStack.Count)
         *      // do we return here?
         *      squareStack.Pop()
         *      return
         *    
         *    NumSquaresRecursive(remainder, listOfSquares, squareIdx + 1, squareStack)
         *    
         *    squareStack.Pop()
         *  

        /**

        //foreach (var square in listSquares)
        for (int sq = 0; sq < listSquares.Count; sq++)
        {
            int square = listSquares[sq];
            // Get the maximum number of square's in n
            int squareCount = remainder / square;

            for (int s = 0; s <= squareCount; s++)
            {
                if (s > 0)
                {
                    // Update our counting data structures
                    squareCounts[square] = squareCount;
                }

                // Now work out the remainder
                int squareAmount = s * square;
                remainder -= squareAmount;

                int squareCountSum = GetZeroRemainderSquareCount(remainder, squareCounts);
                if (squareCountSum > 0)
                {
                    squareCountSums.Add(squareCountSum);
                }
                for (int i = sq + 1; i < listSquares.Count; i++)
                {

                }
            }
            */
    }

        return squareCountSums.First();

        throw new System.Exception("Internal logic error.");
    }

private int GetZeroRemainderSquareCount(int remainder, SortedDictionary<int, int> squareCounts)
{
    if (remainder == 0)
    {
        //var sb = new StringBuilder("Explanation :");
        //foreach (var kv in squareCounts)
        //    sb.AppendLine(kv.Value + " x " + kv.Key);

        //System.Console.WriteLine(sb.ToString());
        return squareCounts.Sum(x => x.Value);
    }

    return 0;
}
}
