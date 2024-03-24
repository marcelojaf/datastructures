using System.Runtime.InteropServices;

namespace LinkedList;

public class ListNodeUtils
{
    /// <summary>
    /// Creates a singly linked list from an array of integers. Each element in the array becomes a node in the linked list,
    /// preserving the order of elements. If the input array is null or empty, the method returns null, indicating an empty list.
    /// This implementation uses a dummy head node to simplify the list construction process, which is not included in the final list.
    /// </summary>
    /// <param name="values">The array of integer values to be converted into a linked list.</param>
    /// <returns>The head of the newly created linked list if the input array is not null or empty; otherwise, returns null.</returns>
    public static ListNode CreateLinkedList(int[] values)
    {
        // Checks if the input array is null or empty and returns null to indicate no list can be created.
        if (values == null || values.Length == 0)
        {
            return null;
        }

        // Creates a dummy head node to facilitate the easy addition of new nodes.
        ListNode dummyHead = new ListNode(-1);
        ListNode current = dummyHead;

        // Iterates over each value in the input array, creating a new node for each and appending it to the end of the list.
        foreach (int val in values)
        {
            current.next = new ListNode(val);
            current = current.next; // Moves the current pointer to the new node.
        }

        // Returns the head of the newly created list by skipping over the dummy head.
        return dummyHead.next;
    }

    public static ListNode CreateLinkedListWithCycle(int[] values, int pos)
    {

        if (values == null || values.Length == 0)
        {
            return null;
        }

        ListNode dummyHead = new ListNode(-1);
        ListNode currentNode = dummyHead;
        ListNode cycleStartNode = null;


        for (int i = 0; i < values.Length; i++)
        {
            currentNode.next = new ListNode(values[i]);
            currentNode = currentNode.next;
            if (i == pos)
            {
                cycleStartNode = currentNode;
            }
        }

        if (cycleStartNode != null)
        {
            currentNode.next = cycleStartNode;
        }

        return dummyHead.next;
    }

    public static ListNode GetNodeWhereCycleStart(ListNode head)
    {
        if (head == null) return null;

        ListNode slow = head;
        ListNode fast = head;
        bool hasCycle = false;

        // First part: Detect whether a cycle exists
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                hasCycle = true;
                break;
            }
        }

        // If a cycle exists, find the node where the cycle begins
        if (hasCycle)
        {
            ListNode pointer1 = head;
            ListNode pointer2 = slow; // slow and fast are at the same node within the cycle

            while (pointer1 != pointer2)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }
            return pointer1; // or pointer2, both are at the start of the cycle
        }

        // No cycle detected
        return null;
    }

    public static ListNode ReverseListNode(ListNode head)
    {
        if (head == null)
            return null;
        if (head.next == null)
        {
            return head;
        }
        ListNode current = head;
        ListNode prev = null;
        ListNode nextTemp = null;
        ListNode newHead = null;
        while (current.next != null)
        {
            prev = current.next;
            nextTemp = current.next.next;

            if (newHead == null)
            {
                prev.next = current;
            }
            else
            {
                prev.next = newHead;
            }

            newHead = prev;
            current.next = nextTemp;
        }

        return newHead;
    }

    /// <summary>
    /// Remove all nodes where val equals to the parameter
    /// </summary>
    /// <param name="head"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static ListNode RemoveElements(ListNode head, int val)
    {
        // Initialize a dummy head to simplify edge cases
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode current = head;
        ListNode prev = dummy;

        while (current != null)
        {
            if (current.val == val)
            {
                prev.next = current.next;
            }
            else
            {
                prev = current;
            }
            current = current.next;
        }

        return dummy.next;
    }

    /// <summary>
    /// Reorders the list by grouping all nodes with odd indices together followed by those with even indices.
    /// </summary>
    /// <param name="head">The head of the singly linked list.</param>
    /// <returns>The head of the reordered list.</returns>
    /// <remarks>
    /// This method achieves O(n) time complexity and O(1) space complexity,
    /// preserving the relative order within both the odd and even groups.
    /// </remarks>
    public static ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode odd = head, even = head.next, evenHead = even;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            odd = odd.next;
            even.next = odd.next;
            even = even.next;
        }

        // Connect the end of the odd list to the head of the even list
        odd.next = evenHead;

        return head;
    }

    /// <summary>
    /// Detects whether a cycle exists within a linked list.
    /// </summary>
    /// <param name="head">The head node of the linked list to be checked for a cycle.</param>
    /// <returns>
    /// A boolean value indicating whether a cycle exists within the linked list.
    /// True if there is a cycle, false otherwise.
    /// </returns>
    /// <remarks>
    /// This method uses Floyd's Tortoise and Hare algorithm, which involves two pointers
    /// moving at different speeds. If there is a cycle, these pointers will eventually meet;
    /// otherwise, the faster pointer will reach the end of the list.
    /// </remarks>
    public static bool DetectCycle(ListNode head)
    {
        if (head == null || head.next == null) return false;

        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next; // Slow pointer moves one step
            fast = fast.next.next; // Fast pointer moves two steps
            if (slow == fast) return true; // Cycle detected
        }

        return false; // No cycle found
    }


    public static string PrintLinkedList(ListNode head)
    {
        string result = "";

        while (head != null)
        {
            result += head.val + " -> ";
            head = head.next;
        }

        return result;
    }
}
