/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                result[index] = i - index;
            }
            stack.Push(i);
        }
        return result;
    }
}
// @lc code=end

