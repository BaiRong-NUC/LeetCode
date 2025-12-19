/*
 * @lc app=leetcode.cn id=106 lang=csharp
 *
 * [106] 从中序与后序遍历序列构造二叉树
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
    public TreeNode Build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
    {
        if (inStart > inEnd || postStart > postEnd)
        {
            return null;
        }
        int rootVal = postorder[postEnd];
        TreeNode root = new TreeNode(rootVal);
        int k = 0;
        for (int i = inStart; i <= inEnd; i++)
        {
            if (inorder[i] == rootVal)
            {
                k = i;
                break;
            }
        }
        int leftTreeSize = k - inStart;
        root.left = Build(inorder, inStart, k - 1, postorder, postStart, postStart + leftTreeSize - 1);
        root.right = Build(inorder, k + 1, inEnd, postorder, postStart + leftTreeSize, postEnd - 1);
        return root;
    }
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if (inorder == null || postorder == null || inorder.Length != postorder.Length || inorder.Length == 0)
        {
            return null;
        }
        return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }
}
// @lc code=end

