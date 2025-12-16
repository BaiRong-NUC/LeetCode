/*
 * @lc app=leetcode.cn id=108 lang=csharp
 *
 * [108] 将有序数组转换为二叉搜索树
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
    public TreeNode BuildBST(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return null;
        }
        int mid = left + (right - left) / 2;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = BuildBST(nums, left, mid - 1);
        root.right = BuildBST(nums, mid + 1, right);
        return root;
    }
    public TreeNode SortedArrayToBST(int[] nums)
    {
        // 选择中间数字作为二叉搜索树的根节点，这样分给左右子树的数字个数相同或只相差1,可以使得树保持平衡
        return BuildBST(nums, 0, nums.Length - 1);
    }
}
// @lc code=end

