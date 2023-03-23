using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day5
    {
        private static readonly IEnumerable<char> Vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        private static readonly IEnumerable<string> ForbiddenPairs = new List<string> { "ab", "cd", "pq", "xy" };

        private Regex pairEitherSide = new Regex(@"(\w)\w\1");
        private Regex twoPairs = new Regex(@"(\w\w)\w*\1");
        private Regex letterPair = new Regex(@"(\w)\1");
                
        public bool StringIsNice(string input)
        {
            return ContainsAtLeastThreeVowels(input) && ContainsDouble(input) && !ContainsForbiddenPairs(input);
        }

        public bool ContainsAtLeastThreeVowels(string input)
        {
            return input.Where(c => Vowels.Contains(c)).Count() >= 3;
        }

        public bool ContainsDouble(string input)
        {
            return letterPair.IsMatch(input);
        }

        public bool ContainsForbiddenPairs(string input)
        {
            foreach (var pair in ForbiddenPairs)
            {
                if (input.Contains(pair)) return true;
            }
            return false;
        }

        public int NumberOfNiceStrings(string input)
        {
            return input.SplitOnNewLines().Select(StringIsNice).Count(x => x);
        }

        public int NumberOfNiceStrings2(string input)
        {
            return input.SplitOnNewLines().Count(IsNice2);
        }
        
        public bool IsNice2(string input)
        {
            return pairEitherSide.IsMatch(input) && twoPairs.IsMatch(input);
        }
    }
}
