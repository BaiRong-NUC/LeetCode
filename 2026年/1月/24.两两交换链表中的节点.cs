/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
    public ListNode SwapPairs(ListNode head)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode current = dummy;

        while (current.next != null && current.next.next != null)
        {
            ListNode first = current.next;
            ListNode second = current.next.next;

            first.next = second.next;
            second.next = first;
            current.next = second;

            current = first;
        }

        return dummy.next;
    }
}
// @lc code=end

