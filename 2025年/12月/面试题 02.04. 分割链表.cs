
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

public class Solution
{
    public ListNode Partition(ListNode head, int x)
    {
        // 补头
        ListNode dummy = new ListNode(0, head);
        ListNode newHead = new ListNode(0);
        ListNode tail = newHead;

        ListNode cur = head;
        ListNode curPrev = dummy;
        while (cur != null)
        {
            ListNode next = cur.next;
            if (cur.val < x)
            {
                // 将 cur 从原链表中摘除
                curPrev.next = cur.next;
                cur.next = null;
                // 加入到新链表尾部
                tail.next = cur;
                tail = tail.next;
            }
            else
            {
                curPrev = cur;
            }
            cur = next;
        }
        tail.next = dummy.next;
        return newHead.next;
    }
}