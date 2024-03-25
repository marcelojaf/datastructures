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
        int[] myList = new int[n];
        int index1 = 0;
        int index2 = 0;
        int valueToAdd = 0;
        int maxValue = 0;

        foreach (var row in queries)
        {
            index1 = row[0];
            index2 = row[1];
            valueToAdd = row[2];

            myList[index1] += valueToAdd;
            myList[index2] += valueToAdd;
            if (myList[index1] >= myList[index2])
            {
                maxValue = myList[index1];
            }
            else
            {
                maxValue = myList[index2];
            }
        }

        return maxValue;
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
