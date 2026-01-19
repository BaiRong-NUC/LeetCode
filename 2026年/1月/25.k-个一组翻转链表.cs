/*
 * @lc app=leetcode.cn id=25 lang=csharp
 *
 * [25] K 个一组翻转链表
 */
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode ReverseLinkedList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        while (current != null)
        {
            ListNode nextTemp = current.next;
            current.next = prev;
            prev = current;
            current = nextTemp;
        }
        return prev; // 新的头节点
    }
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        // 补头节点
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode tail = dummy;
        ListNode left = head;
        ListNode right = head;
        while (left != null)
        {
            for (int i = 1; i < k; i++)
            {
                if (right.next == null)
                {
                    tail.next = left; // 连接剩余节点
                    return dummy.next; // 不足 k 个，直接返回结果
                }
                right = right.next;
            }
            // 反转[left, right]
            ListNode nextGroupHead = right.next; // 保存下一组的头节点
            right.next = null; // 截断当前组
            ListNode groupHead = ReverseLinkedList(left);
            // 连接反转后的组
            tail.next = groupHead;
            // 更新 tail 和 left、right 指针
            tail = left;
            left = nextGroupHead;
            right = nextGroupHead;
        }
        return dummy.next;
    }
}
// @lc code=end

