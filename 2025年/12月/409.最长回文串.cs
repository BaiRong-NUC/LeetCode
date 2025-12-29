/*
 * @lc app=leetcode.cn id=409 lang=csharp
 *
 * [409] 最长回文串
 */

// @lc code=start
public class Solution
{
    public int LongestPalindrome(string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            charCount[ch] = charCount.GetValueOrDefault(ch, 0) + 1;
        }
        int ret = 0;
        // 偶数直接相加,奇数-1后相加
        foreach (char ch in charCount.Keys)
        {
            if (charCount[ch] % 2 == 0)
            {
                ret += charCount[ch];
            }
            else
            {
                ret += charCount[ch] - 1;
            }
        }
        return ret < s.Length ? ret + 1 : ret;
    }
}
// @lc code=end

