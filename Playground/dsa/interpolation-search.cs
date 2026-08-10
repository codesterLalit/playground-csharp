namespace Play.dsa;

public static class InterpolationSearch
{
    public static void Run()
    {
        // Roughly uniform spacing — the case this algorithm is built for
        int[] sorted = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

        Console.WriteLine(Search(sorted, 70));   // 6
        Console.WriteLine(Search(sorted, 10));   // 0
        Console.WriteLine(Search(sorted, 100));  // 9
        Console.WriteLine(Search(sorted, 55));   // -1 (not found)
    }

    public static int Search(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        // Loop guard also rejects targets outside the value range
        while (low <= high && target >= arr[low] && target <= arr[high])
        {
            // Single-element range, or all values equal: avoid divide-by-zero
            if (arr[low] == arr[high])
            {
                return arr[low] == target ? low : -1;
            }

            // long intermediate guards against overflow on large values
            long numerator = (long)(target - arr[low]) * (high - low);
            int pos = low + (int)(numerator / (arr[high] - arr[low]));

            if (arr[pos] == target)
                return pos;

            if (arr[pos] < target)
                low = pos + 1;
            else
                high = pos - 1;
        }

        return -1;
    }
}
