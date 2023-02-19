namespace TextStatisticCollector.utils;

class WordStatisticCollector : IWordStatisticCollector
{
    public Dictionary<string, int> CollectStatistic(IEnumerable<string> words)
    {
        var statistic = new Dictionary<string, int>();
        foreach (var word in words)
            if (!statistic.ContainsKey(word))
                statistic[word] = 1;
            else
                statistic[word]++;

        return statistic;
    }
}