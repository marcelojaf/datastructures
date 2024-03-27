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

    /// <summary>
    /// Provides test data for testing array manipulation.
    /// Each test case consists of three parts: the size of the array (n), 
    /// a list of operations (queries) where each operation is represented as a list of three integers [start index, end index, value to add], 
    /// and the expected maximum value in the array after all operations have been performed.
    /// </summary>
    public static IEnumerable<object[]> MaxValueAfterOperationsData => new List<object[]>
    {
        new object[]
        {
            5,
            new List<List<int>>
            {
                new List<int> { 1, 2, 100 },
                new List<int> { 2, 5, 100 },
                new List<int> { 3, 4, 100 }
            },
            200
        },
        // Adding the requested test case
        new object[]
        {
            10, // Array size
            new List<List<int>>
            {
                new List<int> { 1, 5, 3 },
                new List<int> { 4, 8, 7 },
                new List<int> { 6, 9, 1 }
            },
            10 // Expected maximum value
        }
    };

    [Theory]
    [MemberData(nameof(MaxValueAfterOperationsData))]
    public void MaxValueAfterOperations_ReturnsMaxValue(int n, List<List<int>> queries, int expectedMaxValue)
    {
        // Arrange & Act
        long actualMaxValue = ArrayUtils.arrayManipulation(n, queries);

        // Assert
        Assert.Equal(expectedMaxValue, actualMaxValue);
    }

    [Theory(DisplayName = "FirstMissingPositive")]
    [InlineData(new int[] { 1, 2, 0 }, 3)]
    [InlineData(new int[] { 3, 4, -1, 1 }, 2)]
    [InlineData(new int[] { 7, 8, 9, 11, 12 }, 1)]
    [InlineData(new int[] { 4, 2, 1 }, 3)]
    [InlineData(new int[] { 4, 3, 2, 1 }, 5)]
    [InlineData(new int[] { 2, 1 }, 3)]
    [InlineData(new int[] { 5, 1 }, 2)]
    [InlineData(new int[] { 500, 499, 321, 1 }, 2)]
    public void FirstMissingPositive_WithValidData_ShouldReturnExpectedResult(int[] nums, int expected)
    {
        // Arrange & Act
        int result = ArrayUtils.FirstMissingPositive(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}