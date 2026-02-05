/*
 * @lc app=leetcode.cn id=98 lang=csharp
 *
 * [98] 验证二叉搜索树
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
    bool Validate(TreeNode node, int? lower, int? upper)
    {
        if (node == null) return true;

        int val = node.val;
        if (lower.HasValue && val <= lower.Value) return false;
        if (upper.HasValue && val >= upper.Value) return false;

        if (!Validate(node.right, val, upper)) return false;
        if (!Validate(node.left, lower, val)) return false;
        return true;
    }

    public bool IsValidBST(TreeNode root)
    {
        return Validate(root, null, null);
    }
}
// @lc code=end

