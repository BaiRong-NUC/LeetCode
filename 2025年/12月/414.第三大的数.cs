/*
 * @lc app=leetcode.cn id=414 lang=csharp
 *
 * [414] 第三大的数
 */

// @lc code=start
public class Solution
{
    public int ThirdMax(int[] nums)
    {
        // 默认升序排列
        SortedSet<int> set = new SortedSet<int>();
        foreach (var num in nums)
        {
            set.Add(num);
            if (set.Count > 3)
            {
                set.Remove(set.Min);
            }
        }
        return set.Count == 3 ? set.Min : set.Max;
    }
}
// @lc code=end

