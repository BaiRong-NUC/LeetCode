/*
 * @lc app=leetcode.cn id=394 lang=csharp
 *
 * [394] 字符串解码
 */
using System.Text;
// @lc code=start
public class Solution
{
    public string DecodeString(string s)
    {
        StringBuilder result = new StringBuilder();
        Stack<string> stringStack = new Stack<string>();
        Stack<int> countStack = new Stack<int>();
        int index = 0;
        int count = 0;
        while (index < s.Length)
        {
            if (char.IsDigit(s[index]))
            {
                count = count * 10 + (s[index] - '0');
            }
            else if (s[index] == '[')
            {
                countStack.Push(count);
                stringStack.Push(result.ToString());
                result.Clear();
                count = 0;
            }
            else if (s[index] == ']')
            {
                int repeatCount = countStack.Pop();
                string prevString = stringStack.Pop();
                StringBuilder str = new StringBuilder(prevString);
                for (int i = 0; i < repeatCount; i++)
                {
                    str.Append(result);
                }
                result = str;
            }
            else
            {
                result.Append(s[index]);
            }
            index++;
        }
        return result.ToString();
    }
}
// @lc code=end

