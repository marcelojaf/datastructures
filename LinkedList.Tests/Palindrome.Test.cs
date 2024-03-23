using Xunit.Sdk;

namespace LinkedList.Tests;

public class PalindromeTests
{
    [Fact]
    public void IsPalindrome_WithEvenLengthPalindrome_ShouldReturnTrue()
    {
        // Arrange
        var myList = ListNodeUtils.CreateLinkedList(new int[] { 1, 2, 2, 1 });

        // Act & Assert
        Assert.True(Palindrome.IsPalindrome(myList));
    }

    [Fact]
    public void IsPalindrome_WithOddLengthPalindrome_ShouldReturnTrue()
    {
        // Arrange
        var myList = ListNodeUtils.CreateLinkedList(new int[] { 1, 4, 3, 4, 1 });

        // Act & Assert
        Assert.True(Palindrome.IsPalindrome(myList));
    }

    [Fact]
    public void IsPalindrome_WithNonPalindrome_ShouldReturnFalse()
    {
        // Arrange
        var myList = ListNodeUtils.CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });

        // Act & Assert
        Assert.False(Palindrome.IsPalindrome(myList));
    }

    [Fact]
    public void IsPalindrome_WithSingleElement_ShouldReturnTrue()
    {
        // Arrange
        var myList = ListNodeUtils.CreateLinkedList(new int[] { 1 });

        // Act & Assert
        Assert.True(Palindrome.IsPalindrome(myList));
    }

    [Fact]
    public void IsPalindrome_WithEmptyList_ShouldReturnTrue()
    {
        // Arrange
        var myList = ListNodeUtils.CreateLinkedList(new int[] { });

        // Act & Assert
        Assert.True(Palindrome.IsPalindrome(myList));
    }

}
