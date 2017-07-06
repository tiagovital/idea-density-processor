using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Infrastructure.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static bool IsInTitleCase(this string str)
        {
            var capitalizedStr = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);

            return capitalizedStr == str;
        }

        public static string ToTitleCase(this string str)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public static IEnumerable<string> SplitIntoSentences(this string str)
        {
            return Regex.Split(str, @"(?<=[\.!\?])\s+");
        }

        public static IEnumerable<string> SplitIntoWords(this string str)
        {
            var wordsMatches = Regex.Matches(str, @"\b[\w]*\b");

            foreach (Match item in wordsMatches)
            {
                if (!string.IsNullOrEmpty(item.Value))
                {
                    yield return item.Value;
                }
            }
        }
    }
}