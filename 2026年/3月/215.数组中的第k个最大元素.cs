/*
 * @lc app=leetcode.cn id=215 lang=csharp
 *
 * [215] 数组中的第K个最大元素
 */

// @lc code=start
public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // PopK 算法
        var heap = new PriorityQueue<int, int>(); // 小堆
        foreach (var num in nums)
        {
            heap.Enqueue(num, num);
            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }
        return heap.Peek();
    }
}
// @lc code=end

