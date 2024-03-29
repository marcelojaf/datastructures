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
        int indexToIgnore = 0;
        long sumTemp = 0;
        List<long> sumArray = new List<long>();
        while (indexToIgnore < arr.Count)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (i != indexToIgnore)
                {
                    sumTemp += arr[i];
                }
            }
            indexToIgnore++;
            sumArray.Add(sumTemp);
            sumTemp = 0;
        }


        long minSum = sumArray[0];
        long maxSum = sumArray[0];
        foreach (long val in sumArray)
        {
            if (val > maxSum)
                maxSum = val;

            if (val < minSum)
                minSum = val;
        }

        Console.WriteLine($"{minSum} {maxSum}");
    }

    public static int findMedian(List<int> arr)
    {
        var newArray = BubbleSort(arr);

        return newArray[newArray.Count / 2];
    }

    public static List<int> BubbleSort(List<int> arr)
    {
        bool swapped = true;
        while (swapped)
        {
            swapped = false;
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    // Swap the elements
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    swapped = true; // A swap occurred, indicating that the list was not sorted.
                }
            }
        }
        return arr;
    }

    public static int lonelyinteger(List<int> intArray)
    {
        int lonelyInt = 0;
        List<int> repeatedNumbers = new List<int>();
        List<int> checkedNumbers = new List<int>();
        checkedNumbers.Add(intArray[0]);
        for (int i = 1; i < intArray.Count; i++)
        {
            if (checkedNumbers.Any(num => num == intArray[i]))
            {
                repeatedNumbers.Add(intArray[i]);
                continue;
            }

            if (intArray[i] == intArray[i - 1])
            {
                repeatedNumbers.Add(intArray[i]);
            }
            checkedNumbers.Add(intArray[i]);
        }

        lonelyInt = checkedNumbers.Where(num => !repeatedNumbers.Contains(num)).FirstOrDefault();

        return lonelyInt;
    }

    public static int diagonalDifference(List<List<int>> arr)
    {
        int primaryDiagonalSum = 0, secondaryDiagonalSum = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            primaryDiagonalSum += arr[i][i];
            secondaryDiagonalSum += arr[i][arr.Count - 1 - i];
        }

        return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
    }


    public static List<int> countingSort(List<int> arr)
    {
        int[] result = new int[5];

        foreach (var item in arr)
        {
            result[item]++;
        }

        return result.ToList();
    }


    public static int flippingMatrix(List<List<int>> matrix)
    {
        int n = matrix.Count / 2;
        int maximumSum = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int valorAtual = matrix[i][j];
                int valorHorizontal = matrix[i][2 * n - j - 1];
                int valorVertical = matrix[2 * n - i - 1][j];
                int valorDiagonal = matrix[2 * n - i - 1][2 * n - j - 1];

                int maxValor = Math.Max(
                    valorAtual,
                    Math.Max(valorHorizontal, Math.Max(valorVertical, valorDiagonal))
                );

                maximumSum += maxValor;
            }
        }

        return maximumSum;
    }

    public static List<int> ReverseList(List<int> listToReverse)
    {
        int[] listArray = listToReverse.ToArray();

        var reversedArray = listArray.Reverse();

        return reversedArray.ToList();
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
