/*
 * @lc app=leetcode.cn id=42 lang=csharp
 *
 * [42] 接雨水
 */

// @lc code=start
public class Solution
{
    public int Trap(int[] height)
    {
        // 维护一个单调递减栈（存储索引）
        // 当遇到比栈顶高的柱子时，形成凹槽可以接水
        Stack<int> stack = new Stack<int>();
        int totalWater = 0;

        for (int i = 0; i < height.Length; i++)
        {
            // 当前柱子高度大于栈顶柱子，可以接水
            while (stack.Count > 0 && height[i] > height[stack.Peek()])
            {
                int bottom = stack.Pop(); // 凹槽底部

                if (stack.Count == 0) break; // 没有左边界，无法接水

                int left = stack.Peek(); // 左边界
                int right = i; // 右边界（当前位置）

                // 计算这一层能接的水
                int h = Math.Min(height[left], height[right]) - height[bottom];
                int width = right - left - 1;
                totalWater += h * width;
            }

            stack.Push(i); // 当前柱子入栈
        }

        return totalWater;
    }
}
// @lc code=end

