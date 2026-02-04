/*
 * @lc app=leetcode.cn id=543 lang=csharp
 *
 * [543] 二叉树的直径
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
    public int TreeHeight(TreeNode node)
    {
        if (node == null) return 0;
        int leftHeight = TreeHeight(node.left);
        int rightHeight = TreeHeight(node.right);
        return Math.Max(leftHeight, rightHeight) + 1;
    }
    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null) return 0;
        int leftHeight = TreeHeight(root.left);
        int rightHeight = TreeHeight(root.right);
        int leftDiameter = DiameterOfBinaryTree(root.left);
        int rightDiameter = DiameterOfBinaryTree(root.right);
        return Math.Max(leftHeight + rightHeight, Math.Max(leftDiameter, rightDiameter));
    }
}
// @lc code=end

