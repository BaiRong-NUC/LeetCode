/*
 * @lc app=leetcode.cn id=43 lang=csharp
 *
 * [43] 字符串相乘
 */
// @lc code=start
public class Solution
{

    public string Multiply(string num1, string num2)
    {
        // 使用字符串模拟竖式乘法
        // 1. 判断正负
        bool isNegative = (num1[0] == '-' ^ num2[0] == '-');
        // 2. 去掉符号
        if (num1[0] == '-') num1 = num1.Substring(1);
        if (num2[0] == '-') num2 = num2.Substring(1);
        // 3. 初始化结果数组,数组保存每一位的乘积结果
        int m = num1.Length, n = num2.Length;
        int[] result = new int[m + n];
        // 4. 让长的字符串作为被乘数
        string multiplicand = m >= n ? num1 : num2; // 被乘数
        string multiplier = m >= n ? num2 : num1; // 乘数(位数小于等于被乘数)
        // 5. 逐位相乘
        for (int i = multiplier.Length - 1; i >= 0; i--)
        {
            int carry = 0; // 进位
            int n2 = multiplier[i] - '0';
            for (int j = multiplicand.Length - 1; j >= 0; j--)
            {
                int n1 = multiplicand[j] - '0';
                int sum = n1 * n2 + carry;
                result[i + j + 1] += sum % 10;
                // 处理当前位置的进位,需要考虑到进位导致的下一位进位
                carry = sum / 10 + result[i + j + 1] / 10;
                result[i + j + 1] = result[i + j + 1] % 10;
            }
            // 处理乘数当前位乘完后剩余的进位
            int pos = i;
            while (carry > 0)
            {
                result[pos] += carry;
                carry = result[pos] / 10;
                result[pos] = result[pos] % 10;
                pos--;
            }
        }
        // 6. 构建结果字符串
        StringBuilder sb = new StringBuilder();
        if (isNegative && !(result[0] == 0 && sb.Length == 0)) sb.Append('-');
        foreach (var digit in result)
        {
            if (sb.Length == 0 && digit == 0) continue; // 跳过前导零
            sb.Append(digit);
        }
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
// @lc code=end

