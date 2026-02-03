/*
 * @lc app=leetcode.cn id=226 lang=csharp
 *
 * [226] 翻转二叉树
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
    // public TreeNode InvertTree(TreeNode root)
    // {
    //     if (root == null) return null;
    //     TreeNode left = InvertTree(root.left);
    //     TreeNode right = InvertTree(root.right);
    //     root.left = right;
    //     root.right = left;
    //     return root;
    // }
    #endregion
    #region 迭代
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            // 交换左右子节点
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
        return root;
    }
    #endregion
}
// @lc code=end

