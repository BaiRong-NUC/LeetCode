/*
 * @lc app=leetcode.cn id=230 lang=csharp
 *
 * [230] 二叉搜索树中第 K 小的元素
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
    // 记录每个节点的子节点数量
    public Dictionary<TreeNode, int> nodeCount = new Dictionary<TreeNode, int>();
    int InitNodeCount(TreeNode node)
    {
        if (node == null) return 0;
        int leftCount = InitNodeCount(node.left);
        int rightCount = InitNodeCount(node.right);
        this.nodeCount[node] = leftCount + rightCount + 1;
        return this.nodeCount[node];
    }
    public int KthSmallest(TreeNode root, int k)
    {
        this.InitNodeCount(root);
        TreeNode node = root; 
        while (node != null)
        {
            int leftCount = node.left != null ? this.nodeCount[node.left] : 0;
            if (k <= leftCount)
            {
                node = node.left;
            }
            else if (k == leftCount + 1)
            {
                return node.val;
            }
            else
            {
                k -= leftCount + 1;
                node = node.right;
            }
        }
        return -1;
    }
}
// @lc code=end

