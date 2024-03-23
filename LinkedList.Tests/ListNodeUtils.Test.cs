namespace LinkedList.Tests;

public class ListNodeUtilsTests
{
    [Fact]
    public void CreateLinkedList_WithValidInput_ShouldCreateCorrectLinkedList()
    {
        // Arrange
        int[] values = new int[] { 2, 4, 6, 7, 8, 2 };
        ListNode expectedList = new ListNode(2, new ListNode(4, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(2))))));

        // Act
        var actualList = ListNodeUtils.CreateLinkedList(values);

        // Assert
        Assert.True(AreListsEqual(expectedList, actualList));
    }

    [Fact]
    public void CreateLinkedList_WithNullInput_ShouldReturnNull()
    {
        // Arrange
        int[] values = null;

        // Act
        var actualList = ListNodeUtils.CreateLinkedList(values);

        // Assert
        Assert.Null(actualList);
    }

    [Fact]
    public void CreateLinkedList_WithEmptyInput_ShouldReturnNull()
    {
        // Arrange
        int[] values = new int[] { };

        // Act
        var actualList = ListNodeUtils.CreateLinkedList(values);

        // Assert
        Assert.Null(actualList);
    }

    /// <summary>
    /// Compares two singly linked lists for equality.
    /// Two lists are considered equal if they have the same number of nodes and corresponding nodes have equal values.
    /// </summary>
    /// <param name="head1">The head of the first linked list.</param>
    /// <param name="head2">The head of the second linked list.</param>
    /// <returns>True if both linked lists are equal; otherwise, false.</returns>
    private bool AreListsEqual(ListNode head1, ListNode head2)
    {
        // Initialize pointers to the start of both lists
        ListNode current1 = head1, current2 = head2;

        // Iterate through both lists simultaneously
        while (current1 != null && current2 != null)
        {
            // If the values of the current nodes don't match, the lists are not equal
            if (current1.val != current2.val)
            {
                return false;
            }

            // Move to the next node in both lists
            current1 = current1.next;
            current2 = current2.next;
        }

        // After iterating, check if both lists have reached their ends (both are null)
        // If only one list has ended, the lists are not equal
        return current1 == null && current2 == null;
    }

}