/*
 * @lc app=leetcode.cn id=105 lang=csharp
 *
 * [105] 从前序与中序遍历序列构造二叉树
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
    private TreeNode BuildTreeHelper(
        int[] preorder, int preStart, int preEnd,
        int[] inorder, int inStart, int inEnd,
        Dictionary<int, int> inorderIndexMap
    )
    {
        if (preStart > preEnd || inStart > inEnd)
            return null;

        int rootVal = preorder[preStart];
        TreeNode root = new TreeNode(rootVal);

        int inorderRootIndex = inorderIndexMap[rootVal];
        int leftTreeSize = inorderRootIndex - inStart;

        root.left = BuildTreeHelper(preorder, preStart + 1, preStart + leftTreeSize,
                                    inorder, inStart, inorderRootIndex - 1,
                                    inorderIndexMap);
        root.right = BuildTreeHelper(preorder, preStart + leftTreeSize + 1, preEnd,
                                    inorder, inorderRootIndex + 1, inEnd,
                                    inorderIndexMap);

        return root;
    }
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder == null || inorder == null || preorder.Length != inorder.Length)
            return null;

        Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderIndexMap[inorder[i]] = i;
        }

        return BuildTreeHelper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inorderIndexMap);
    }
}
// @lc code=end

