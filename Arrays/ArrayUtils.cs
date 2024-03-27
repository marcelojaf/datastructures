namespace Arrays;

public class ArrayUtils
{
    public static int FindDuplicate(int[] nums)
    {
        // Phase 1: Finding the intersection point of the two runners.
        int tortoise = nums[0];
        int hare = nums[0];
        do
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        } while (tortoise != hare);

        // Phase 2: Find the entrance to the cycle.
        tortoise = nums[0];
        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }

        return hare;
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return [];

        int[] result = [2];

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int k = 1; // Start from 1 because the first element is always unique
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    public static int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0) return 0;

        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    public static List<int> matchingStrings(List<string> stringList, List<string> queries)
    {
        int[] result = new int[queries.Count];
        int queryCount = 0;

        foreach (string val in queries)
        {
            foreach (string strVal in stringList)
            {
                if (val == strVal)
                {
                    result[queryCount]++;
                }
            }
            queryCount++;
        }

        return result.ToList();
    }

    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        long[] myList = new long[n + 1]; // Use long to avoid overflow and +1 for easier handling of 1-based index
        long maxValue = 0;

        foreach (var query in queries)
        {
            int index1 = query[0] - 1; // Adjust for 0-based index
            int index2 = query[1]; // Use index2 for marking the end of the addition
            int valueToAdd = query[2];

            myList[index1] += valueToAdd;
            if (index2 < n) myList[index2] -= valueToAdd; // Decrease the value right after index2 to reverse the addition effect later
        }

        long tempSum = 0;
        for (int i = 0; i < n; i++)
        {
            tempSum += myList[i];
            if (tempSum > maxValue) maxValue = tempSum;
        }

        return maxValue;
    }

    // THIS IS A SOLUTION ACCEPTED BUT I DONT'T UNDERSTAND
    // public static int FirstMissingPositive(int[] nums)
    // {
    //     int n = nums.Length;

    //     // Step 1: Move all non-positive integers to the end of the array
    //     int nonPosIdx = 0;
    //     for (int i = 0; i < n; i++)
    //     {
    //         if (nums[i] <= 0)
    //         {
    //             int temp = nums[i];
    //             nums[i] = nums[nonPosIdx];
    //             nums[nonPosIdx] = temp;
    //             nonPosIdx++;
    //         }
    //     }

    //     // Step 2: Mark the presence of positive integers by negating the corresponding index
    //     for (int i = nonPosIdx; i < n; i++)
    //     {
    //         int num = Math.Abs(nums[i]);
    //         if (num <= n - nonPosIdx && nums[num - 1 + nonPosIdx] > 0)
    //         {
    //             nums[num - 1 + nonPosIdx] *= -1;
    //         }
    //     }

    //     // Step 3: Find the first missing positive integer
    //     for (int i = nonPosIdx; i < n; i++)
    //     {
    //         if (nums[i] > 0)
    //         {
    //             return i - nonPosIdx + 1;
    //         }
    //     }

    //     return n - nonPosIdx + 1;
    // }

    public static int FirstMissingPositive(int[] nums)
    {
        int tempIndex = nums.Length;

        for (int i = 0; i < tempIndex; ++i)
        {
            // While the current number can be placed in a "correct" position that is different from the current position
            // and the target position does not already contain the correct number,
            // swap the numbers.
            while (nums[i] > 0 && nums[i] <= tempIndex && nums[nums[i] - 1] != nums[i])
            {
                // Swap nums[i] and nums[nums[i] - 1]
                int temp = nums[i];
                nums[i] = nums[temp - 1];
                nums[temp - 1] = temp;
            }
        }

        // Find the first number that is not at its correct position.
        for (int i = 0; i < tempIndex; ++i)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        // If all numbers are in their correct positions, the missing one is n + 1.
        return tempIndex + 1;
    }

    public static void plusMinus(List<int> arr)
    {
        if (arr == null || arr.Count == 0)
        {
            Console.WriteLine("Empty list");
            return;
        }

        int n = arr.Count;
        int positiveNumbers = 0;
        int negativeNumbers = 0;
        int zeroNumbers = 0;

        foreach (int val in arr)
        {
            if (val == 0)
                zeroNumbers++;
            else if (val > 0)
                positiveNumbers++;
            else
                negativeNumbers++;
        }

        decimal positiveRatio = Math.Round((decimal)positiveNumbers / n, 6);
        decimal negativeRatio = Math.Round((decimal)negativeNumbers / n, 6);
        decimal zeroRatio = Math.Round((decimal)zeroNumbers / n, 6);

        Console.WriteLine(positiveRatio.ToString("F6"));
        Console.WriteLine(negativeRatio.ToString("F6"));
        Console.WriteLine(zeroRatio.ToString("F6"));
    }

    public static void miniMaxSum(List<int> arr)
    {
        if (arr == null || arr.Count == 0)
        {
            Console.WriteLine("Empty list");
            return;
        }

        int min = arr[0];
        int max = arr[0];
        // Get maximum and minimum value
        foreach (int val in arr)
        {
            if (val < min)
                min = val;
            else if (val > max)
                max = val;
        }

        int minSum = 0;
        int maxSum = 0;
        foreach (int val in arr)
        {
            if (val < max || val == min)
                minSum += val;
            if (val > min || val == max)
                maxSum += val;

        }

        Console.WriteLine($"{minSum} {maxSum}");
    }

    public static string PrintArray(int[] nums)
    {
        string result = "";
        for (int i = 0; i < nums.Length; i++)
        {
            result += nums[i].ToString() + ",";
        }

        return result;
    }
}
