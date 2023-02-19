namespace TextStatisticCollector.utils;

public interface IWordStatisticCollector
{
    Dictionary<string, int> CollectStatistic(IEnumerable<string> words);
}