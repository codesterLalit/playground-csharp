namespace Play.delegates;

public static class Ex01_BasicDelegatess
{
    // TODO 1: no `where` clause needed here — that's the point.
    //         scoreSelector is how the caller tells you how to get a score from T.
    public static T HighestBy<T>(IEnumerable<T> items, Func<T, int> scoreSelector)
    {
        T? best = default;
        int bestScore = int.MinValue;

        foreach(var item in items)
        {
            int score = scoreSelector(item);
            if(score > bestScore)
            {
                bestScore = score;
                best = item;
            }
        }
        return best ?? throw new InvalidOperationException("No items provided");
    }

    public static void Run()
    {
        var players = new[]
        {
            (Name: "Ana", Score: 70),
            (Name: "Bilal", Score: 95),
            (Name: "Chen", Score: 88),
        };

        // TODO 3: call HighestBy(players, p => p.Score), print the winner's Name.
        var winner = HighestBy(players, p=> p.Score);
        Console.WriteLine($"Winner: {winner.Name} ({winner.Score})");

        string[] words = { "kiwi", "watermelon", "fig", "pomegranate" };

        // TODO 4: call HighestBy(words, w => w.Length) — proves the same method
        //         works on a type (string) with no custom interface at all.
        var longestWords = HighestBy(words, w => w.Length);
        Console.WriteLine($"Longest word: {longestWords} ({longestWords.Length})");
    }
}
