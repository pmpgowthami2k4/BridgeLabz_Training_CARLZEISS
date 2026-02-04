public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;        // move 1 step
            fast = fast.next.next;  // move 2 steps
        }

        return slow;
    }
}

