namespace Play.fun;

public static class Ex14_CollectionInterfaces
{
    public static double Average(IEnumerable<int> numbers)
    {
        return numbers.Average();
    }

    public static void PrintIndexed(IReadOnlyList<string> strings)
    {
        for (int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine($"{i}: {strings[i]}");
        }
    }

    public static string TopScorer(IReadOnlyDictionary<string, int> scores)
    {
        string topName = string.Empty;
        int topScore = int.MinValue;

        foreach(var (name, score) in scores)
        {
            if(score > topScore)
            {
                topScore = score;
                topName = name;
            }
        }
        return topName;
    }

    public static void Run()
    {
        int[] scoresArray = { 70, 88, 95, 60};
        List<string> names = new() {"Ana", "Bilal", "Chenn", "Deepa"};
        Dictionary<string, int> nameToScore = new()
        {
          ["Ana"] = 70,
          ["Bilal"] = 88,
          ["Chenn"] = 95,
          ["Deepa"] = 60   
        };

        double averageScore = Average(scoresArray);
        Console.WriteLine($"Average score: {averageScore}");

        PrintIndexed(names);

        string topScorer = TopScorer(nameToScore);
        Console.WriteLine($"Top scorer: {topScorer}");
    }
}