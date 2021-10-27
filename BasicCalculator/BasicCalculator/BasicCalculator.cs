/*
 * @lc app=leetcode id=224 lang=csharp
 *
 * [224] Basic Calculator
 *
 * https://leetcode.com/problems/basic-calculator/description/
 *
 * algorithms
 * Hard (35.90%)
 * Total Accepted:    153.2K
 * Total Submissions: 424K
 * Testcase Example:  '"1 + 1"'
 *
 * Implement a basic calculator to evaluate a simple expression string.
 * 
 * The expression string may contain open ( and closing parentheses ), the plus
 * + or minus sign -, non-negative integers and empty spaces  .
 * 
 * Example 1:
 * 
 * 
 * Input: "1 + 1"
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: " 2-1 + 2 "
 * Output: 3
 * 
 * Example 3:
 * 
 * 
 * Input: "(1+(4+5+2)-3)+(6+8)"
 * Output: 23
 * Note:
 * 
 * STACK
 * (, (1, (1+, (1+(, ... (1+(4+5+2, (1+(, eval(4+5+2), (1+11-, (1+11-3, eval 1+11-3, 9+, 9+(...
 * 
 * 
 * You may assume that the given expression is always valid.
 * Do not use the eval built-in library function.
 * 
 * 1-(6+(2-9))+3
 * 
 * 1, 1-, 1-(, 1-(6, 1-(6+, 1-(6+2, 1-(6+2+0)
 * 
 * 1 + 23 - 319
 * 1,+,23,-319
 * 1,23,+,319,-
 * chars = +-
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    const string OPERATORS = "()+-";
    int sum = 0;
    int idx = 0;

    public int Calculate(string s)
    {
        string strippedS = new string(s.Where(x => x != ' ').ToArray());
        strippedS = strippedS + "|";
        int sum = 0;
        var currNumStr = new StringBuilder();
        int currNum = 0;
        bool isAdding = true;
        for (int i = 0; i < strippedS.Length; i++)
        {
            char c = strippedS[i];
            if (c == '-' || c == '+')
            {
                currNum = int.Parse(currNumStr.ToString());
                sum += isAdding ? currNum : -1 * currNum;

                isAdding = c == '+';
                currNumStr.Clear();
            }
            else if (c == '|')
            {
                if (currNumStr.ToString().Length > 0)
                {
                    currNum = int.Parse(currNumStr.ToString());
                    sum += isAdding ? currNum : -1 * currNum;
                }
            }
            else
            {
                currNumStr.Append(c);
            }
        }

        return sum;
    }
    //private int Evaluate(int sum, string s)
    //{
    //    if (idx >= s.Length)
    //        return 0;

    //    char curr = s[idx++];
    //    if (curr == '(')
    //    {
    //        return sum + Evaluate(sum, s);
    //    }
    //    else if (curr == ')')
    //    {
    //        return sum;
    //    }
    //    else if (curr == '+')
    //    {
    //        return sum + Evaluate(sum, s);
    //    }
    //    else if (curr == '-')
    //    {
    //        return sum - Evaluate(sum, s);
    //    }
    //    else
    //    {
    //        return int.Parse(s[idx] + "");
    //    }
    //}



    //interface CalcChar
    //{
    //    int Eval(int sum, Stack<CalcChar> stack);
    //}

    //class Operator : CalcChar
    //{
    //    private string v;

    //    public Operator(string v)
    //    {
    //        this.v = v;
    //    }

    //    public int Eval(int sum, Stack<CalcChar> stack)
    //    {
    //        if (stack.Count > 0)
    //        {
    //            var op = stack.Pop();
    //        }
    //    }
    //}

    //class Operand : CalcChar
    //{
    //    private string v;

    //    public Operand(string v)
    //    {
    //        this.v = v;
    //    }


    //    public int Eval(int sum, Stack<CalcChar> stack)
    //    {
    //        return int.Parse(v);
    //    }
    //}


    //public int Calculate(string s) {

    //    var stack = new Stack<CalcChar>();
    //    foreach (char c in s)
    //    {
    //        if (OPERATORS.Contains(c + ""))
    //        {
    //            stack.Push(new Operator(c + ""));
    //        }
    //        else
    //        {
    //            stack.Push(new Operand(c + ""));
    //        }
    //    }

    //    return _Calculate(stack);
    //}

    //private int _Calculate(Stack<CalcChar> stack)
    //{
    //    int res = 0;
    //    while (stack.Count > 0)
    //    {
    //        var op = stack.Pop();
    //        res += op.Eval(res, stack);
    //    }

    //    return res;
    //}
}
