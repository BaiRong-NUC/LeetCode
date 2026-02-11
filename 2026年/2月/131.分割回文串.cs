/*
 * @lc app=leetcode.cn id=131 lang=csharp
 *
 * [131] 分割回文串
 */

// @lc code=start
public class Solution
{
    public bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    public void Backtracking(string s, int startIndex, List<string> path, List<IList<string>> result)
    {
        if (startIndex >= s.Length)
        {
            result.Add([.. path]);
            return;
        }
        for (int i = startIndex; i < s.Length; i++)
        {
            string substring = s.Substring(startIndex, i - startIndex + 1);
            if (this.IsPalindrome(substring))
            {
                path.Add(substring);
                this.Backtracking(s, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
    public IList<IList<string>> Partition(string s)
    {
        List<IList<string>> result = new List<IList<string>>();
        this.Backtracking(s, 0, new List<string>(), result);
        return result;
    }
}
// @lc code=end

