using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode
{
    public class Day5
    {
        private static readonly IEnumerable<char> Vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        private static readonly IEnumerable<string> ForbiddenPairs = new List<string> { "ab", "cd", "pq", "xy" };

        public bool StringIsNice(string input)
        {
            var split = input.BreakToPairs();
            return ContainsAtLeastThreeVowels(input) && ContainsDouble(split) && !ContainsForbiddenPairs(split);
        }

        public bool ContainsAtLeastThreeVowels(string input)
        {
            return input.Where(c => Vowels.Contains(c)).Count() >= 3;
        }

        public bool ContainsDouble(IEnumerable<string> pairs)
        {
            return pairs.Any(p => p[0] == p[1]);
        }

        public bool ContainsForbiddenPairs(IEnumerable<string> pairs)
        {
            return pairs.Any(p => ForbiddenPairs.Contains(p));
        }

        public int NumberOfNiceStrings(string input)
        {
            return input.SplitOnNewLines().Select(StringIsNice).Count(x => x);
        }
    }
}
