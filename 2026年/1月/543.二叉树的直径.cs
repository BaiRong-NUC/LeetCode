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
    int maxDiameter = 0;
    public int Height(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftHeight = Height(node.left);
        int rightHeight = Height(node.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null)
            return 0;
        int leftHeight = Height(root.left);
        int rightHeight = Height(root.right);
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);
        DiameterOfBinaryTree(root.left);
        DiameterOfBinaryTree(root.right);
        return maxDiameter;
    }
}
// @lc code=end

