/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
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
    #region 递归
    // private bool IsMirror(TreeNode t1, TreeNode t2)
    // {
    //     if (t1 == null && t2 == null) return true;
    //     if (t1 == null || t2 == null) return false;
    //     return (t1.val == t2.val)
    //         && IsMirror(t1.left, t2.right)
    //         && IsMirror(t1.right, t2.left);
    // }
    // public bool IsSymmetric(TreeNode root)
    // {
    //     if (root == null) return true;
    //     return IsMirror(root.left, root.right);
    // }
    #endregion

    #region 迭代
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null) return true;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root.left);
        queue.Enqueue(root.right);
        while (queue.Count > 0)
        {
            TreeNode t1 = queue.Dequeue();
            TreeNode t2 = queue.Dequeue();
            if (t1 == null && t2 == null) continue;
            if (t1 == null || t2 == null) return false;
            if (t1.val != t2.val) return false;

            queue.Enqueue(t1.left);
            queue.Enqueue(t2.right);
            queue.Enqueue(t1.right);
            queue.Enqueue(t2.left);
        }
        return true;
    }
    #endregion
}
// @lc code=end

