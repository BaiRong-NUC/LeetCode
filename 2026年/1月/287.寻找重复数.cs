/*
 * @lc app=leetcode.cn id=287 lang=csharp
 *
 * [287] 寻找重复数
 */

// @lc code=start
public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        // 第一步：快慢指针找到环中的相遇点
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            slow = nums[slow];           // 慢指针走一步
            fast = nums[nums[fast]];     // 快指针走两步
        } while (slow != fast);

        // 第二步：找环的入口（重复的数字）
        // 一个指针从起点，一个从相遇点，同速前进
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;  // 相遇点即为重复的数字
    }
}
// @lc code=end


/*
解题思路：

1. **问题转换**：
   - 数组索引范围：[0, n]
   - 数组值范围：[1, n]
   - 将数组看作隐式链表：索引 i 的下一个节点是索引 nums[i]
   - 因为有重复数字 x，多个索引会指向 x，形成环

2. **Floyd 判圈算法（龟兔赛跑）**：
   - 第一阶段：快慢指针找相遇点
     * 慢指针每次走 1 步：slow = nums[slow]
     * 快指针每次走 2 步：fast = nums[nums[fast]]
     * 在环内某处相遇
   
   - 第二阶段：找环的入口
     * 一个指针从起点 nums[0]，一个从相遇点
     * 两者同速前进，相遇点就是环入口（重复数字）

3. **示例追踪 [1,3,4,2,2]**：
   
   链表关系：
   0 -> 1 -> 3 -> 2 -> 4 -> 2 (环)
                   ↑         ↓
                   └─────────┘
   
   - 起点是索引 0，值为 nums[0] = 1
   - 从 1 出发：1 -> 3 -> 2 -> 4 -> 2 -> 4...
   - 环的入口是 2（重复的数字）
   
   快慢指针过程：
   slow: 1 -> 3 -> 2 -> 4 -> 2
   fast: 1 -> 3 -> 4 -> 2 -> 4 -> 2
   在 2 或 4 处相遇
   
   然后从起点和相遇点同速前进，会在 2 处相遇

4. **为什么这样有效**：
   - 设起点到环入口距离为 a，环长为 b
   - 快慢指针相遇时，slow 走了 s 步，fast 走了 2s 步
   - fast 比 slow 多走的距离恰好是环长的整数倍
   - 数学推导保证从起点和相遇点同速前进必在环入口相遇
*/

