public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {

        // dummy node before head
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode fast = dummy;
        ListNode slow = dummy;

        // move fast pointer n steps ahead
        for (int i = 0; i < n; i++)
        {
            fast = fast.next;
        }

        // move both until fast reaches last node
        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        // remove nth node from end
        slow.next = slow.next.next;

        return dummy.next;
    }
}
