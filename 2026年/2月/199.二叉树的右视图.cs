/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
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
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                // 每层的最后一个节点就是右视图节点
                if (i == size - 1)
                {
                    result.Add(node.val);
                }
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
        return result;
    }
}
// @lc code=end

