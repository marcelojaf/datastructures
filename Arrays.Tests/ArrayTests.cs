using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Arrays.Tests;

public class ArrayTests
{
    [Theory]
    [InlineData(new int[] { 2, 5, 5, 11 }, 10, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void FindsIndicesThatSumToTarget(int[] nums, int target, int[] expected)
    {
        // Act
        var result = ArrayUtils.TwoSum(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new int[] { 0, 1, 2, 3, 4 })]
    [InlineData(new int[] { 2, 2, 2 }, new int[] { 2 })]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
    [InlineData(new int[] { }, new int[] { })]
    public void RemoveDuplicates(int[] nums, int[] expected)
    {
        // Act
        var k = ArrayUtils.RemoveDuplicates(nums);

        // Assert
        Assert.Equal(expected.Length, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(nums[i], expected[i]);
        }
    }

    [Theory]
    [InlineData(new string[] { "ab", "ab", "abc" }, new string[] { "ab", "abc", "bc" }, new int[] { 2, 1, 0 })]
    public void MatchingStrings_WithValidData_ShouldReturnExpectedIntList(string[] stringArray, string[] queryArray, int[] expectedArray)
    {
        // Arrange
        List<string> stringList = new List<string>(stringArray);
        List<string> queries = new List<string>(queryArray);
        List<int> expected = new List<int>(expectedArray);

        // Act
        List<int> result = ArrayUtils.matchingStrings(stringList, queries);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, new int[][] { new int[] { 1, 2, 100 }, new int[] { 2, 5, 100 }, new int[] { 3, 4, 100 } }, 200)]

    public void MaxValueAfterOperations_ReturnsMaxValue(int n, int[][] queriesArray, int expectedMaxValue)
    {
        var queries = queriesArray.Select(q => q.ToList()).ToList();

        // Act
        long actualMaxValue = ArrayUtils.arrayManipulation(n, queries);

        // Assert
        Assert.Equal(expectedMaxValue, actualMaxValue);
    }
}