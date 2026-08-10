namespace Play.dsa;

public static class BinarySearch
{
    public static void Run()
    {
        int[] sorted = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

        Console.WriteLine(Search(sorted, 23));  // 5
        Console.WriteLine(Search(sorted, 91));  // 9
        Console.WriteLine(Search(sorted, 7));   // -1 (not found)
    }

    public static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;

            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}
