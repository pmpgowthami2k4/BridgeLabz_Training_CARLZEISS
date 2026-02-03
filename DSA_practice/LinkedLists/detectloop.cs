using System;
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class DetectLoop
{
    public bool HasCycle(ListNode head)
    {
        if (head == null || head.next == null)
            return false;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;          // move 1 step
            fast = fast.next.next;    // move 2 steps

            if (slow == fast)
                return true;           // cycle detected
        }

        return false;                  // no cycle
    }
}

