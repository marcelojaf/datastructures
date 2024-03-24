namespace LinkedList.Tests;

public class ListNodeUtilsTests
{
    [Fact]
    public void CreateLinkedList_WithValidInput_ShouldCreateCorrectLinkedList()
    {
        // Arrange
        int[] values = [2, 4, 6, 7, 8, 2];
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
        int[] values = [];

        // Act
        var actualList = ListNodeUtils.CreateLinkedList(values);

        // Assert
        Assert.Null(actualList);
    }

    [Fact]
    public void CreateLinkedListWithCycle_WithEmptyInput_ShouldReturnNull()
    {
        // Arrange
        int[] values = [];

        // Act
        var actualList = ListNodeUtils.CreateLinkedListWithCycle(values, -1);

        // Assert
        Assert.Null(actualList);
    }

    [Fact]
    public void CreateLinkedListWithCycle_WithNoCycle_ShouldReturnLinearList()
    {
        // Arrange
        int[] values = [1, 2, 3, 4];

        // Act
        var listHead = ListNodeUtils.CreateLinkedListWithCycle(values, -1);
        bool hasCycle = ListNodeUtils.DetectCycle(listHead);

        // Assert
        Assert.False(hasCycle);
    }

    [Fact]
    public void CreateLinkedListWithCycle_WithCycleAtBeginning_ShouldDetectCycle()
    {
        // Arrange
        int[] values = [1, 2, 3, 4];

        // Act
        var listHead = ListNodeUtils.CreateLinkedListWithCycle(values, 0);
        bool hasCycle = ListNodeUtils.DetectCycle(listHead);

        // Assert
        Assert.True(hasCycle);
    }

    [Fact]
    public void CreateLinkedListWithCycle_WithCycleInMiddle_ShouldDetectCycle()
    {
        // Arrange
        int[] values = [1, 2, 3, 4, 5];

        // Act
        var listHead = ListNodeUtils.CreateLinkedListWithCycle(values, 2);
        bool hasCycle = ListNodeUtils.DetectCycle(listHead);

        // Assert
        Assert.True(hasCycle);
    }

    [Fact]
    public void CreateLinkedListWithCycle_WithNullInput_ShouldReturnNull()
    {
        // Arrange
        int[] values = null;

        // Act
        var actualList = ListNodeUtils.CreateLinkedListWithCycle(values, -1);

        // Assert
        Assert.Null(actualList);
    }

    [Fact]
    public void GetNodeWhereCycleStart_With4LinkedListCycle_ShouldReturnCorrectNode()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedListWithCycle([3, 2, 0, -4], 1);

        // Act
        var nodeWhereCycleStart = ListNodeUtils.GetNodeWhereCycleStart(listNode);

        // Assert
        Assert.Equal(2, nodeWhereCycleStart.val);
    }

    [Fact]
    public void GetNodeWhereCycleStart_With2ItemLinkedListCycle_ShouldReturnCorrectNode()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedListWithCycle([1, 2], 0);

        // Act
        var nodeWhereCycleStart = ListNodeUtils.GetNodeWhereCycleStart(listNode);

        // Assert
        Assert.Equal(1, nodeWhereCycleStart.val);
    }

    [Fact]
    public void GetNodeWhereCycleStart_With10ItemLinkedListCycle_ShouldReturnCorrectNode()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedListWithCycle([-1, -7, 7, -4, 19, 6, -9, -5, -2, -5], 6);

        // Act
        var nodeWhereCycleStart = ListNodeUtils.GetNodeWhereCycleStart(listNode);

        // Assert
        Assert.Equal(-9, nodeWhereCycleStart.val);
    }

    [Fact]
    public void RemoveElements_WithMoreThanTwoValues_ShouldReturnCorrectNode()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedList([1, 2, 6, 3, 4, 5, 6]);

        // Act
        var trimmedList = ListNodeUtils.RemoveElements(listNode, 6);

        // Assert against a utility method to compare linked lists
        Assert.True(AreListsEqual(trimmedList, [1, 2, 3, 4, 5]));
    }

    [Fact]
    public void RemoveElements_WithHeadValueMatching_ShouldRemoveHeadCorrectly()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedList([1, 2]);

        // Act
        var trimmedList = ListNodeUtils.RemoveElements(listNode, 1);

        // Assert
        Assert.True(AreListsEqual(trimmedList, [2]));
    }

    [Fact]
    public void OddEvenList_WithFiveNodes_ShouldReorderCorrectly()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedList([1, 2, 3, 4, 5]);

        // Act
        var reorderedList = ListNodeUtils.OddEvenList(listNode);

        // Assert
        Assert.True(AreListsEqual(reorderedList, [1, 3, 5, 2, 4]));
    }

    [Fact]
    public void OddEvenList_WithSevenNodesMixedValues_ShouldReorderCorrectly()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedList([2, 1, 3, 5, 6, 4, 7]);

        // Act
        var reorderedList = ListNodeUtils.OddEvenList(listNode);

        // Assert
        Assert.True(AreListsEqual(reorderedList, [2, 3, 6, 7, 1, 5, 4]));
    }

    [Fact]
    public void OddEvenList_WithEightNodes_ShouldReorderCorrectly()
    {
        // Arrange
        ListNode listNode = ListNodeUtils.CreateLinkedList([1, 2, 3, 4, 5, 6, 7, 8]);

        // Act
        var reorderedList = ListNodeUtils.OddEvenList(listNode);

        // Assert
        Assert.True(AreListsEqual(reorderedList, [1, 3, 5, 7, 2, 4, 6, 8]));
    }

    private static bool AreListsEqual(ListNode head, int[] values)
    {
        int i = 0;
        while (head != null)
        {
            if (i >= values.Length || head.val != values[i])
            {
                return false;
            }
            head = head.next;
            i++;
        }
        return i == values.Length; // Ensure all values matched and no extra nodes exist
    }

    /// <summary>
    /// Compares two singly linked lists for equality.
    /// Two lists are considered equal if they have the same number of nodes and corresponding nodes have equal values.
    /// </summary>
    /// <param name="head1">The head of the first linked list.</param>
    /// <param name="head2">The head of the second linked list.</param>
    /// <returns>True if both linked lists are equal; otherwise, false.</returns>
    private static bool AreListsEqual(ListNode head1, ListNode head2)
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