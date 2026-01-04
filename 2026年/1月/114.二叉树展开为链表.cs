/*
 * @lc app=leetcode.cn id=114 lang=csharp
 *
 * [114] 二叉树展开为链表
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
    private void PreOrderTraversal(TreeNode node, List<TreeNode> nodeList)
    {
        if (node == null)
        {
            return;
        }
        nodeList.Add(node);
        PreOrderTraversal(node.left, nodeList);
        PreOrderTraversal(node.right, nodeList);
    }
    public void Flatten(TreeNode root)
    {
        List<TreeNode> nodeList = new List<TreeNode>();
        PreOrderTraversal(root, nodeList);
        // 重新连接节点
        for (int i = 1; i < nodeList.Count; i++)
        {
            TreeNode prevNode = nodeList[i - 1];
            TreeNode currNode = nodeList[i];
            prevNode.left = null;
            prevNode.right = currNode;
        }
    }
}
// @lc code=end

