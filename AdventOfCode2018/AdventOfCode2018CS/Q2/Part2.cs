using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018CS.Q2
{
    public static class Part2
    {
        public static string CommonBetween(this string input)
        {
            var lines = input.SplitOnNewLines();
            return lines
                .SelectMany(line => lines.Select(x => new KeyValuePair<string, string>(line, x)))
                .Select(kvp => new
                {
                    OneCharacterDifferent = OneCharacterDifferent(kvp.Key, kvp.Value),
                    Key = kvp.Key,
                    Value = kvp.Value
                })
                .Where(x => x.OneCharacterDifferent)
                .Select(x => MatchingCharacters(x.Key, x.Value))
                .First();
        }
        
        public static bool OneCharacterDifferent(string x, string y)
        {
            return x
                .Zip(y, (first, second) => new { first, second })
                .Where(z => z.first != z.second)
                .Count() == 1;
        }

        public static string MatchingCharacters(string x, string y)
        {
            return new string(x
                .Zip(y, (first, second) => new { first, second })
                .Where(z => z.first == z.second)
                .Select(z=>z.first)
                .ToArray());
        }
    }
}
