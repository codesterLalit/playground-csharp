namespace Play.dsa;

public static class JumpSearch
{
    public static void Run()
    {
        int[] sorted = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

        Console.WriteLine(Search(sorted, 23));  // 5
        Console.WriteLine(Search(sorted, 2));   // 0
        Console.WriteLine(Search(sorted, 7));   // -1 (not found)
    }

    public static int Search(int[] arr, int target)
    {
        int n = arr.Length;
        if (n == 0) return -1;

        int step = (int)Math.Floor(Math.Sqrt(n));
        if (step < 1) step = 1;

        int prev = 0;
        int curr = step;

        // Jump forward while the last element of the block is still below target
        while (curr < n && arr[curr - 1] < target)
        {
            prev = curr;
            curr += step;
        }

        // Linear scan inside the block we landed on
        int end = Math.Min(curr, n);
        for (int i = prev; i < end; i++)
        {
            if (arr[i] == target) return i;
        }

        return -1;
    }
}
