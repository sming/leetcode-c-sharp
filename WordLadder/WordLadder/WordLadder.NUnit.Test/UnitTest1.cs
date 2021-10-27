using System.Collections.Generic;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void Test1()
    {
        string beginWord = "hit";
        string endWord = "cog";
        var wordList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };

        var solution = new Solution();
        Assert.AreEqual(5, solution.LadderLength(beginWord, endWord, wordList));
    }


    [Test]
    public void Test2()
    {
        string beginWord = "hot";
        string endWord = "dog";
        var wordList = new List<string>() { "hot", "dog" };

        var solution = new Solution();
        Assert.AreEqual(0, solution.LadderLength(beginWord, endWord, wordList));
    }

    [Test]
    public void Test3()
    {
        string beginWord = "qa";
        string endWord = "sq";
        var wordList = new List<string>() {
            "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" };

        var solution = new Solution();
        Assert.AreEqual(5, solution.LadderLength(beginWord, endWord, wordList));
    }

    [Test]
    public void Test4()
    {
        string beginWord = "a";
        string endWord = "c";
        var wordList = new List<string>() { "a", "b", "c" };

        var solution = new Solution();
        Assert.AreEqual(2, solution.LadderLength(beginWord, endWord, wordList));
    }
}
