using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeGeneratorGreen.Extentions
{
    public static class StringExtentions
    {
        public static string ToAngularFrendlyName(this String str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
                return str;
            var words =
                Regex.Matches(str, @"([A-Z][a-z]+)")
                    .Cast<Match>()
                    .Select(m => m.Value);

            return string.Join("-", words).ToLower();
        }
        public static string FirstCharacterToLower(this String str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
                return str;

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}
