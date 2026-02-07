/*
 * @lc app=leetcode.cn id=124 lang=csharp
 *
 * [124] 二叉树中的最大路径和
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
    // 获取以 node 为根节点的最大路径值
    int MaxGain(TreeNode node, ref int maxPath)
    {
        if (node == null) return 0;
        int leftGain = Math.Max(MaxGain(node.left, ref maxPath), 0);
        int rightGain = Math.Max(MaxGain(node.right, ref maxPath), 0);
        // 构成新路径
        int priceNewPath = node.val + leftGain + rightGain;
        maxPath = Math.Max(maxPath, priceNewPath);
        //返回可能构成的最大回路的一半,当前node + 较大的一边 
        return node.val + Math.Max(leftGain, rightGain);
    }

    public int MaxPathSum(TreeNode root)
    {
        int maxPath = int.MinValue;
        MaxGain(root, ref maxPath);
        return maxPath;
    }
}
// @lc code=end

