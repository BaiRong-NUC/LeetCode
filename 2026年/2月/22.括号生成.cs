/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if (c == ')' && top != '(')
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    public void Backtracking(List<string> res, string path, int length)
    {
        if (path.Length == length)
        {
            if (this.IsValid(path)) { res.Add(path); }
            return;
        }
        this.Backtracking(res, path + '(', length);
        this.Backtracking(res, path + ')', length);
    }
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> res = new List<string>();
        this.Backtracking(res, "", 2 * n);
        return res;
    }
}
// @lc code=end

