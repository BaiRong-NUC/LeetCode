/*
 * @lc app=leetcode.cn id=39 lang=csharp
 *
 * [39] 组合总和
 */

// @lc code=start
public class Solution
{
    private void Backtracking(int[] candidates, int target, List<IList<int>> res, List<int> path, int start)
    {
        if (target < 0) return;
        if (target == 0)
        {
            res.Add([.. path]);
            return;
        }
        for (int i = start; i < candidates.Length; i++)
        {
            path.Add(candidates[i]);
            this.Backtracking(candidates, target - candidates[i], res, path, i);
            path.RemoveAt(path.Count - 1);
        }
    }
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        this.Backtracking(candidates, target, res, new List<int>(), 0);
        return res;
    }
}
// @lc code=end

