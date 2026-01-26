/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
public class Solution
{
    // 暴力解法
    // public int[] DailyTemperatures(int[] temperatures)
    // {
    //     int[] ret = new int[temperatures.Length];
    //     for (int i = 0; i < temperatures.Length; i++)
    //     {
    //         for (int j = i + 1; j < temperatures.Length; j++)
    //         {
    //             if (temperatures[j] > temperatures[i])
    //             {
    //                 ret[i] = j - i;
    //                 break;
    //             }
    //         }
    //     }
    //     return ret;
    // }

    // 单调栈
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] ret = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(i);
            }
            else
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int index = stack.Pop();
                    ret[index] = i - index;
                }
                stack.Push(i);
            }
        }
        return ret;
    }
}
// @lc code=end

