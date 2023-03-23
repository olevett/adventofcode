using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018CS.Q2
{
    public static class Part1
    {
        public static int CalculateChecksum(this string input)
        {
            return input.SplitOnNewLines()
                   .Select(CountDoublesAndTriples)
                   .CalculateChecksum();
        }

        public static IntermediateChecksum CountDoublesAndTriples(this string input)
        {
            var characterCount = new Dictionary<char, int>();
            foreach (char x in input)
            {
                if (characterCount.ContainsKey(x))
                {
                    characterCount[x]++;
                }
                else
                {
                    characterCount[x] = 1;
                }
            }

            return new IntermediateChecksum(characterCount.ContainsValue(2), characterCount.ContainsValue(3));
        }

        public static int CalculateChecksum(this IEnumerable<IntermediateChecksum> input)
        {
            int doubles = input.Where(x => x.HasDouble).Count();
            int triples = input.Where(x => x.HasTriple).Count();
            return doubles * triples;
        }

        public class IntermediateChecksum
        {
            public IntermediateChecksum(bool hasDouble, bool hasTriple)
            {
                HasDouble = hasDouble;
                HasTriple = hasTriple;
            }

            public bool HasDouble { get; }
            public bool HasTriple { get; }
        }
    }
}
