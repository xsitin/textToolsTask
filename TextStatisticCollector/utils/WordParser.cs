using System.Text.RegularExpressions;

namespace TextStatisticCollector.utils;

public partial class WordParser : IWordParser
{
    [GeneratedRegex("[а-яА-ЯЁёa-zA-Z]+")]
    private static partial Regex WordSelector();

    public IEnumerable<string> GetWordsFromText(IEnumerable<string> text)
    {
        return text.SelectMany(x => WordSelector().Matches(x).Select(match => match.Value))
            .Where(x => x.Length is >= 3 and <= 20).Select(x => x.ToLower());
    }

    public IEnumerable<string> GetWordsFromText(string text)
    {
        return WordSelector().Split(text);
    }
}