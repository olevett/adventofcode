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
    }
}
