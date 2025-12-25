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
        //每个位置 i 连一条 i→nums[i] 的边。由于存在的重复的数字 target，因此 target 这个位置一定有起码两条指向它的边，因此整张图一定存在环
        int slow = 0, fast = 0;
        while (true)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast)
            {
                break;
            }
        }

        // slow 从相遇点出发，fast 从起点出发，每次走一步，再次相遇点即为重复数字
        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }
        return slow;
    }
}
// @lc code=end

