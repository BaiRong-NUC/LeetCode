/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        // 括号匹配
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char top = stack.Pop();
                if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end

