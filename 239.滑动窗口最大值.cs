/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] result = new int[nums.Length - k + 1];
        // 优先级队列，存储当前窗口内的元素及其索引
        SortedSet<(int value, int index)> window = new SortedSet<(int value, int index)>(Comparer<(int value, int index)>.Create((a, b) =>
        {
            int cmp = b.value.CompareTo(a.value); // 按值降序排列
            return cmp == 0 ? a.index.CompareTo(b.index) : cmp; // 值相同时按索引升序排列
        }));
        // 初始化第一个窗口
        for (int i = 0; i < k; i++)
        {
            window.Add((nums[i], i));
        }
        result[0] = window.First().value;
        // Console.WriteLine(window.First().value);
        for (int i = k; i < nums.Length; i++)
        {
            window.Remove((nums[i - k], i - k));
            window.Add((nums[i], i));
            result[i - k + 1] = window.First().value;
        }
        return result;
    }
}
// @lc code=end

