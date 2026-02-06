/*
 * @lc app=leetcode.cn id=437 lang=csharp
 *
 * [437] 路径总和 III
 */
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    int CountPathsFromNode(TreeNode node, int targetSum)
    {
        if (node == null) return 0;
        int ret = 0;
        long sum = 0;
        Stack<(TreeNode node, long pathSum)> stack = new Stack<(TreeNode, long)>();
        while (stack.Count > 0 || node != null)
        {
            while (node != null)
            {
                sum += node.val;
                if (sum == targetSum) ret++;
                stack.Push((node, sum));
                node = node.left;
            }
            var (poppedNode, poppedSum) = stack.Pop();
            sum = poppedSum;
            node = poppedNode.right;
        }
        return ret;
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null) return 0;
        int rootPaths = CountPathsFromNode(root, targetSum);
        int leftPaths = PathSum(root.left, targetSum);
        int rightPaths = PathSum(root.right, targetSum);
        return leftPaths + rightPaths + rootPaths;
    }
}
// @lc code=end

