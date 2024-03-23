namespace LinkedList;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int value = 0, ListNode next = null)
    {
        this.val = value;
        this.next = next;
    }
}
