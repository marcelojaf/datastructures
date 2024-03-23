using Microsoft.VisualBasic;

namespace LinkedList;

public class Palindrome
{
    public static bool IsPalindrome(ListNode head)
    {
        if ((head == null) || (head.next == null))
            return true;

        ListNode slowPointer = head;
        ListNode fastPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;
        }

        ListNode invertedHalf = null;
        ListNode tempNextNode = null;
        while (slowPointer != null)
        {
            tempNextNode = slowPointer.next;
            slowPointer.next = invertedHalf;
            invertedHalf = slowPointer;
            slowPointer = tempNextNode;
        }

        ListNode left = head;
        ListNode right = invertedHalf;
        while (right != null)
        {
            if (right.val != left.val)
                return false;

            left = left.next;
            right = right.next;
        }

        return true;
    }
}
