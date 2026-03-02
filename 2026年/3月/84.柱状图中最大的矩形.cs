/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = 0;
        Stack<int> stack = new Stack<int>();// 单调栈
        heights = heights.Prepend(0).ToArray(); // 哨兵
        heights = heights.Append(0).ToArray(); // 哨兵
        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Count > 0 && heights[i] < heights[stack.Peek()])
            {
                int curHeight = heights[stack.Pop()];
                int leftIndex = stack.Count > 0 ? stack.Peek() : -1;// 左边界
                int rightIndex = i - 1;// 右边界
                maxArea = Math.Max(maxArea, (rightIndex - leftIndex) * curHeight);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}
// @lc code=end

