/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
 */

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
    public int MaxDepth(TreeNode root)
    {
        // if (root == null) return 0;

        // int leftDepth = MaxDepth(root.left);
        // int rightDepth = MaxDepth(root.right);

        // return Math.Max(leftDepth, rightDepth) + 1;

        // 非递归
        if (root == null) return 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int depth = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            depth++;
        }
        return depth;
    }
}
// @lc code=end

