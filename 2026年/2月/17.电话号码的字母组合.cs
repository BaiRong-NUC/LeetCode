/*
 * @lc app=leetcode.cn id=17 lang=csharp
 *
 * [17] 电话号码的字母组合
 */
using System.Text;
// @lc code=start
public class Solution
{
    public Dictionary<char, string> phoneMap = new Dictionary<char, string>
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };
    public void Backtrack(string digits, int start, StringBuilder path, List<string> res)
    {
        if (start == digits.Length)
        {
            res.Add(path.ToString());
            return;
        }
        char digit = digits[start];
        string letters = phoneMap[digit];
        foreach (char letter in letters)
        {
            path.Append(letter);
            Backtrack(digits, start + 1, path, res);
            path.RemoveAt(path.Length - 1);
        }
    }
    public IList<string> LetterCombinations(string digits)
    {
        List<string> res = new List<string>();
        Backtrack(digits, 0, new StringBuilder(), res);
        return res;
    }
}
// @lc code=end

