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
