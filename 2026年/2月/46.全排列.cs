/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution
{
    public void Backtrack(int[] nums, List<int> path, IList<IList<int>> res)
    {
        if (path.Count == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (path.Contains(nums[i]))
            {
                continue;
            }
            path.Add(nums[i]);
            Backtrack(nums, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Backtrack(nums, new List<int>(), res);
        return res;
    }
}
// @lc code=end

