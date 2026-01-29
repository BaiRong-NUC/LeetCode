/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
 */
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}
// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode pointerA = headA;
        ListNode pointerB = headB;
        while (pointerA != pointerB)
        {
            pointerA = pointerA == null ? headB : pointerA.next;
            pointerB = pointerB == null ? headA : pointerB.next;
        }
        return pointerA;
    }
}
// @lc code=end

