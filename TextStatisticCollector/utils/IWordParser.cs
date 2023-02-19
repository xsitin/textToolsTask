namespace TextStatisticCollector.utils;

public interface IWordParser
{
    IEnumerable<string> GetWordsFromText(IEnumerable<string> text);
    IEnumerable<string> GetWordsFromText(string text);
}