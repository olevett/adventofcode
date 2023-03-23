using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018CS
{
    public static class Helpers
    {
        public static IEnumerable<string> SplitOnNewLines(this string input) => 
            input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        public static IEnumerable<string> SplitOnNewLinesOrCommas(this string input) =>
            input.Split(new[] { ",", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        public static IEnumerable<KeyValuePair<string, string>> Window(this IEnumerable<string> input)
        {
            for (int i = 0; i < input.Count() - 1; i++)
            {
                yield return new KeyValuePair<string, string>(input.ElementAt(i), input.ElementAt(i + 1));
            }
        }
    }
}
