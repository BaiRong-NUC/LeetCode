public class Solution
{
    public bool IsPalindrome(string s, int left, int right, bool canDelete)
    {
        while (left < right)
        {
            if (s[left] != s[right])
            {
                if (canDelete == false)
                {
                    return false;
                }
                // 可以删除,删除一个字符来判断是否是回文串
                bool delLeft = IsPalindrome(s, left + 1, right, false);
                bool delRight = IsPalindrome(s, left, right - 1, false);
                return delLeft || delRight;
            }
            left += 1;
            right -= 1;
        }
        // 遍历完成,是回文串
        return true;
    }
    public bool ValidPalindrome(string s)
    {
        return IsPalindrome(s, 0, s.Length - 1, true);
    }
}