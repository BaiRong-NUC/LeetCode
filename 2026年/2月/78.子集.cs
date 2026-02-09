/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 */

// @lc code=start
public class Solution
{
    public void Backtrack(int[] nums, int start, List<int> path, IList<IList<int>> res)
    {
        res.Add([.. path]);
        for (int i = start; i < nums.Length; i++)
        {
            path.Add(nums[i]);
            Backtrack(nums, i + 1, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        Backtrack(nums, 0, new List<int>(), res);
        return res;
    }
}
// @lc code=end

