using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitOnNewLines(this string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> BreakToPairs(this string input)
        {
            var pairs = new List<string>();
            for (var i = 0; i < input.Length - 1; i++)
            {
                pairs.Add(string.Format("{0}{1}", input[i], input[i + 1]));
            }
            return pairs;
        }
    }
}
