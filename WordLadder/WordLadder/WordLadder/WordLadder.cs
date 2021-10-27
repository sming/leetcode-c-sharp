using System.Linq;
using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=127 lang=csharp
 *
 * [127] Word Ladder
 *
 * https://leetcode.com/problems/word-ladder/description/
 *
 * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
 *
 * Given two words (beginWord and endWord), and a dictionary's word list, find
 * the length of shortest transformation sequence from beginWord to endWord,
 * such that:
 *
 * Only one letter can be changed at a time.
 * Each transformed word must exist in the word list.
 *
 * Note:
 *
 * Return 0 if there is no such transformation sequence.
 * All words have the same length.
 * All words contain only lowercase alphabetic characters.
 * You may assume no duplicates in the word list.
 * You may assume beginWord and endWord are non-empty and are not the same.
 *
 * Example 1:
 * Input:
 * beginWord = "hit",
 * endWord = "cog",
 * wordList = ["hot","dot","dog","lot","log","cog"]
 *
 * Output: 5
 *
 * Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" ->
 * "dog" -> "cog",
 * return its length 5.
 *
 * Example 2:
 * Input:
 * beginWord = "hit"
 * endWord = "cog"
 * wordList = ["hot","dot","dog","lot","log"]
 *
 * Output: 0
 *
 * Explanation: The endWord "cog" is not in wordList, therefore no possible
 * transformation.
 */
public class Solution
{
    private string endWord;
    private IList<string> wordList;
    private int wordLength;
    private bool printDebug = true;
    private Queue<string> queue = new Queue<string>();
    // PARENTS == <child, parent>
    private Dictionary<string, string> childToParent = new Dictionary<string, string>();

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (wordList == null || wordList.Count == 0 || !wordList.Contains(endWord))
            return 0;

        this.endWord = endWord;
        this.wordList = wordList;
        wordLength = wordList[0].Length;
        queue.Enqueue(beginWord);
        childToParent.Add(beginWord, null);

        return LadderLength();
    }

    private int LadderLength()
    {
        while (queue.Count > 0)
        {
            string currentWord = queue.Dequeue();
            if (currentWord == endWord)
            {
                string parent = childToParent[currentWord];
                int counter = 1;
                while (parent != null)
                {
                    parent = childToParent[parent];
                    ++counter;
                }
                Print($"Found end word in {counter} transformations.");
                PrintStack();
                return counter;
            }

            int beforeQueueCount = queue.Count;
            for (int i = 0; i < wordList.Count; i++)
            {
                string iterWord = wordList[i];
                if (IsOneLetterDifferent(iterWord, currentWord) && !childToParent.ContainsKey(iterWord) && !queue.Contains(iterWord))
                {
                    childToParent[iterWord] = currentWord;
                    queue.Enqueue(iterWord);
                }
            }

            Print($"Enqueued {queue.Count - beforeQueueCount} words which are 1 letter different to current word {currentWord}.");
        }

        return 0;
    }

    private void Print(string s, bool isLine = true)
    {
        if (printDebug)
            if (isLine)
                Console.WriteLine(s);
            else
                Console.Write(s);
    }

    private void PrintStack()
    {
        if (printDebug)
        {
            Print("LadderLength: transformation stack: ");
            foreach (var childParent in childToParent)
                Print($"({childParent.Value} <- {childParent.Key}), ", false);

            Print("");
        }
    }

    private bool IsOneLetterDifferent(string a, string b)
    {
        int differingCharsCount = 0;
        for (int i = 0; i < wordLength; i++)
            if (a[i] != b[i])
                if (++differingCharsCount > 1)
                    return false;

        return differingCharsCount == 1;
    }
}