﻿using System.Linq;
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
public class SolutionDFS
{
    private string endWord;
    private IList<string> wordList;
    private int minLength;
    private int wordLength;
    private bool printDebug = true;
    private HashSet<string> currentTransformations = new HashSet<string>();
    private HashSet<Stack<string>> failedStacks = new HashSet<Stack<string>>();

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (wordList == null || wordList.Count == 0 || !wordList.Contains(endWord))
            return 0;

        this.endWord = endWord;
        this.wordList = wordList;
        minLength = int.MaxValue;
        wordLength = wordList[0].Length;

        var transformationStack = new Stack<string>();
        transformationStack.Push(beginWord);
        currentTransformations.Add(beginWord);

        LadderLengthRecursive(transformationStack);
        return minLength == int.MaxValue ? 0 : minLength;
    }

    private bool LadderLengthRecursive(Stack<string> transformationStack)
    {
        PrintStack(transformationStack);

        string currentWord = transformationStack.Peek();
        if (currentWord == endWord)
        {
            minLength = Math.Min(minLength, transformationStack.Count);
            Print($"Found end word in {minLength} transformations.");
            return true;
        }

        for (int i = 0; i < wordList.Count; i++)
        {
            string iterWord = wordList[i];
            if (IsOneLetterDifferent(currentWord, iterWord))
            {
                if (!currentTransformations.Contains(iterWord))
                {
                    Print($"Found word: {iterWord} which is 1 letter different to current word {currentWord}.");
                    currentTransformations.Add(iterWord);
                    transformationStack.Push(iterWord);

                    //if (!failedStacks.Contains(transformationStack))
                    //{
                    if (!LadderLengthRecursive(transformationStack))
                        failedStacks.Add(transformationStack);
                    //}

                    transformationStack.Pop();
                    currentTransformations.Remove(iterWord);
                }
            }
        }

        return false;
    }

    private void Print(string s, bool isLine = true)
    {
        if (printDebug)
            if (isLine)
                Console.WriteLine(s);
            else
                Console.Write(s);
    }

    private void PrintStack(Stack<string> transformationStack)
    {
        Print("LadderLengthRecursive: transformation stack: ");
        foreach (string s in transformationStack)
            Print($"{s} -> ", false);

        Print("");
    }

    private bool IsOneLetterDifferent(string a, string b)
    {
        int differingCharsCount = 0;
        for (int i = 0; i < wordLength; i++)
        {
            if (a[i] != b[i])
            {
                ++differingCharsCount;
                if (differingCharsCount > 1)
                    return false;
            }
        }
        return differingCharsCount == 1;
    }
}